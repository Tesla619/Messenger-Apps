using System.Net;
using System.Net.Sockets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Messenger_v2.Properties;

namespace Messenger_v2
{
    public partial class Form1 : Form
    {
        string recMsg;
        bool clientState = true;
        bool serverState = true;
        NetworkStream clientStream;
        static TcpListener server;
        static TcpClient client = new TcpClient();
        string[] buttonTexts = { "Connect", "Disconnect", "Start", "Stop" };

        //https://www.c-sharpcorner.com/UploadFile/97ec13/how-to-make-a-chat-application-in-C-Sharp/

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //FOR FASTER TESTING
            IP_TextBox.Text = GetLocalIP();
            Port_TextBox.Text = "23";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Stop();
            client.Close();
        }

        private static string GetLocalIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private static string GetPublicIP()
        {
            return new WebClient().DownloadString("http://icanhazip.com").Trim();
        }

        private void Connect_Button_Click(object sender, EventArgs e)
        {
            clientState = !clientState;

            if (clientState == true)
            {
                try
                {
                    client.Close();
                    Connect_Button.Text = buttonTexts[0];       // Connect               
                }
                catch (Exception ex) { clientState = Error_Message(clientState, Connect_Button, buttonTexts[1], ex); } // Disconnect

            }
            else if (clientState == false)
            {
                try
                {
                    Connect_Button.Text = buttonTexts[1]; // Disconnect
                    client.Connect(IP_TextBox.Text, Convert.ToInt32(Port_TextBox.Text));                    
                    //client = server.AcceptTcpClient();
                }
                catch (Exception ex) { clientState = Error_Message(clientState, Connect_Button, buttonTexts[0], ex); } // Connect
            }
        }

        private void Server_Button_Click(object sender, EventArgs e)
        {
            serverState = !serverState;

            if (serverState == true)
            {
                try
                {
                    Server_Button.Text = buttonTexts[2]; // Start
                    server.Stop();
                }
                catch (Exception ex) { serverState = Error_Message(serverState, Server_Button, buttonTexts[3], ex); } // Stop

            }
            else if (serverState == false)
            {
                try
                {
                    Server_Button.Text = buttonTexts[3]; // Stop
                    server = new TcpListener(IPAddress.Parse(GetLocalIP()), Convert.ToInt32(Port_TextBox.Text));
                    server.Start();
                }
                catch (Exception ex) { serverState = Error_Message(serverState, Server_Button, buttonTexts[2], ex); } // Start
            }
        }

        private bool Error_Message(bool state, Button button, string message, Exception e)
        {
            button.Text = message;
            state = !state;
            MessageBox.Show(e.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return state;
        }

        private void Send_Button_Click(object sender, EventArgs e)
        {
            //
            clientStream = client.GetStream();
            sendData(clientStream, Sending_TextBox.Text);            
            Main_TextBox.Text += ID_TextBox.Text + "(You) Sent: " + Sending_TextBox.Text + " " + "\n";
            Sending_TextBox.Text = "";
        }

        private void clientThread()
        {
            try
            {
                #region Sending the ID to the Client
                NetworkStream dataStream = client.GetStream();
                sendData(dataStream, ID_TextBox.Text);
                Console.WriteLine("ID sent, waiting for message... \n");
                #endregion

                #region Main Loop: Receiving Data over the Network, Checking the ID & Responding Accordingly
                while (client.Connected)
                {
                    String responseData = receiveData(dataStream);                                                          //Receiving the message from the client

                    #region Splitting Message to check ID
                    //var firstSplit = responseData.Split('[');
                    //var finalSplit = firstSplit[1].Split(']');
                    #endregion

                    string recMsg = "Message: " + responseData + " received from ID " +
                        ID_TextBox.Text + ".\n";

                    Console.WriteLine(recMsg);
                    sendData(dataStream, "ID Valid, Message Received.");

                    #region Checking ID & responding back to client accordingly
                    /*if (uniqueID.Contains(finalSplit[0]) == true)
                    {
                        string recMsg = "Message: " + finalSplit[1] + " received from ID " +
                        finalSplit[0] + " on thread " + Thread.CurrentThread.ManagedThreadId + ".\n";

                        Console.WriteLine(recMsg);
                        sendData(dataStream, "ID Valid, Message Received.");
                    }
                    else
                    {
                        Console.WriteLine("ID was invalid connection closed.\n");
                        sendData(dataStream, "ID was invalid closing connection.");
                        Thread.Sleep(1000);
                        closeClient();
                    }*/
                    #endregion
                }
                #endregion
            }
            catch (Exception e)                                                                                             //Warning that something went wrong and connection is closing
            {
                Console.WriteLine("\nClosing Connection to Client" + " due to error: " + e.ToString() + "\n");
                closeClient();
            }
        }

        //Closing the Connection, decrementing the counter of clients and removing the uniqueID from the global list
        private void closeClient()
        {
            Console.WriteLine("Client " + " with ID " + ID_TextBox.Text
            + " Disconnected, on thread " + Thread.CurrentThread.ManagedThreadId + ".\n");

            //clientCounter--;
            //uniqueID.Remove(ID_TextBox.Text);
            client.Close();

            //if (uniqueID.Count == 0) Console.WriteLine("Waiting for a connection... \n");                                   //To show that there is no active connection
        }

        //Returning sent string from over the network
        private string receiveData(NetworkStream clientStream)
        {
            Byte[] recvData = new Byte[256];
            Int32 bytesInt = clientStream.Read(recvData, 0, recvData.Length);
            return Encoding.ASCII.GetString(recvData, 0, bytesInt);
        }

        //Sending a string over the network
        private void sendData(NetworkStream clientStream, string sendString)
        {
            Byte[] sendData = new Byte[256];
            sendData = Encoding.ASCII.GetBytes(sendString);
            clientStream.Write(sendData, 0, sendData.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Thread thread = new Thread(new ThreadStart(recData));
            //thread.Start();
            //recData();
        }

        private void recData()
        {
            
        }

        private void checkReceive_DoWork(object sender, DoWorkEventArgs e)
        {
            bool received = false;
            
            while (received == false)
            {
                try
                {
                    clientStream = client.GetStream();
                    recMsg = receiveData(clientStream);

                    if (recMsg != null)
                    {
                        Main_TextBox.Text += ID_TextBox.Text + "(You) Sent: " + Sending_TextBox.Text + " " + "\n";                        
                        //Sending_TextBox.Text = "";
                        received = true;
                    }


                    //return msg;
                }
                catch (Exception) { }
            }
            //return null;
        }
    }
}
