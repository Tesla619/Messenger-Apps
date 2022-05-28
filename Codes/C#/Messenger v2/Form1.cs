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
        bool clientState = true;
        bool serverState = true;
        public static TcpListener server;
        public static TcpClient clientSocket = new TcpClient();
        private static List<string> uniqueID = new List<string>();
        string[] buttonTexts = { "Connect", "Disconnect", "Start", "Stop" };
        

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
            clientSocket.Close();
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
                    clientSocket.Close();
                    Connect_Button.Text = buttonTexts[0];       // Connect               
                }
                catch (Exception ex) { clientState = Error_Message(clientState, Connect_Button, buttonTexts[1], ex); } // Disconnect

            }
            else if (clientState == false)
            {
                try 
                {
                    Connect_Button.Text = buttonTexts[1]; // Disconnect
                    clientSocket.Connect(IP_TextBox.Text, Convert.ToInt32(Port_TextBox.Text)); 
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
            Main_TextBox.Text += "You Sent: " + Sending_TextBox.Text + " " + "\n";
            Sending_TextBox.Text = "";
        }

        public static void Main(string[] args)
        {
            #region Creating Objects for Network Communication
            //TcpClient clientSocket = new TcpClient();
            //TcpListener server = new TcpListener(IPAddress.Parse(IP), port);
            #endregion

            //server.Start();                                                                                             //Starting server to listen for tcp client connection requests
            //Console.WriteLine("Server Started, waiting for a connection... \n");

            while (true)                                                                                                        //main loop
            {
                clientSocket = server.AcceptTcpClient();                                                                //waiting for a tcp client connection
                //if (clientCounter < 0) clientCounter = 0;                                                                       //implemented to fix issue where counter would go below zero
                //clientCounter++;
                handleClient client = new handleClient();
                string clientID = client.generateID();                                                                          //generating a random unique ID

                //Console.WriteLine("Client number " + clientCounter + " has a client ID of " + clientID
                //     + " Connected, on thread " + Thread.CurrentThread.ManagedThreadId + ".\n");

                client.startInitializing(clientSocket, clientID);//, clientCounter);                                                      //Initalzing the client object
            }
        }

        public class handleClient
        {
            #region Creating Global Class Variables & TcpClient Object
            TcpClient client = new TcpClient();
            string clientID = "0";
            int clientNum;
            #endregion

            public void startInitializing(TcpClient inClientSocket, string inClientID)//, int inClientNum)
            {
                #region Inputting passed variables & TcpClient object to global ones
                client = inClientSocket;
                clientID = inClientID;
                //clientNum = inClientNum;
                #endregion

                #region Multi Threading Code
                //clientThread();                                                                                               //Used for testing before implementing multi-threading
                Thread ctThread = new Thread(clientThread);                                                                     //Creating a new thread which will handle the particular client's I/O to the server
                ctThread.Start();                                                                                               //Starting the thread
                #endregion
            }

            private void clientThread()
            {
                try
                {
                    #region Sending the ID to the Client
                    NetworkStream dataStream = client.GetStream();
                    sendData(dataStream, clientID);
                    Console.WriteLine("ID sent, waiting for message... \n");
                    #endregion

                    #region Main Loop: Receiving Data over the Network, Checking the ID & Responding Accordingly
                    while (client.Connected)
                    {
                        String responseData = receiveData(dataStream);                                                          //Receiving the message from the client

                        #region Splitting Message to check ID
                        var firstSplit = responseData.Split('[');
                        var finalSplit = firstSplit[1].Split(']');
                        #endregion

                        #region Checking ID & responding back to client accordingly
                        if (uniqueID.Contains(finalSplit[0]) == true)
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
                        }
                        #endregion
                    }
                    #endregion
                }
                catch (Exception e)                                                                                             //Warning that something went wrong and connection is closing
                {
                    //Console.WriteLine("\nClosing Connection to Client " + clientNum + " due to error: " + e.ToString() + "\n");
                    Console.WriteLine("\nClosing Connection to Client" + " due to error: " + e.ToString() + "\n");
                    closeClient();
                }
            }

            //Generating a random unqiue ID, adding it to the global list of ID's and then returning it as a string
            public string generateID()
            {
                #region Creating Method variable & object
                Random rndGen = new Random();
                bool unique = false;
                #endregion

                #region Generating ID & Checking it is unique
                do
                {
                    int id = rndGen.Next(1, 10000);

                    if (uniqueID.Contains(id.ToString("D4")) == false)
                    {
                        uniqueID.Add(id.ToString("D4"));
                        unique = true;
                    }

                } while (unique == false);
                #endregion

                unique = false;                                                                                                 //Reseting variable

                return uniqueID[uniqueID.Count - 1];
            }

            //Closing the Connection, decrementing the counter of clients and removing the uniqueID from the global list
            private void closeClient()
            {
                Console.WriteLine("Client " + clientNum + " with ID " + clientID
                + " Disconnected, on thread " + Thread.CurrentThread.ManagedThreadId + ".\n");

                //clientCounter--;
                uniqueID.Remove(clientID);
                client.Close();

                if (uniqueID.Count == 0) Console.WriteLine("Waiting for a connection... \n");                                   //To show that there is no active connection
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
        }
    }
}
