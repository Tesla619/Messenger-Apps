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

        //WORKS BUT LOST INTEREST AND DIDN'T POLISH


        TcpListener server = new TcpListener(IPAddress.Parse(GetLocalIPAddress()), 23);
        TcpClient client;
        bool connect_state = true;

        public Form1()
        {
            InitializeComponent();
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public static string GetPublicIP()
        {
            return new WebClient().DownloadString("http://icanhazip.com").Trim();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Starting Server
            server.Start();
            //server.Delimiter = 0x13;//enter
            //server.StringEncoder = Encoding.UTF8;
            //server.DataReceived += Server_DataReceived;

            //FOR FASTER TESTING
            IP_TextBox.Text = GetLocalIPAddress();
            Port_TextBox.Text = "23";

            //Starting Client
            client = new TcpClient();
            //client.StringEncoder = Encoding.UTF8;
        }
        /*

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            //NEED FORMATING

            //Update mesage to txtStatus
            Main_TextBox.Invoke((MethodInvoker)delegate ()
            {
                Main_TextBox.Text += "Received: " + e.MessageString;
                Main_TextBox.Text = Main_TextBox.Text.Remove(Main_TextBox.Text.Length - 1);
                Main_TextBox.Text += "\n";

                e.ReplyLine(string.Format("", e.MessageString));
                Main_TextBox.ForeColor = Color.Black;
            });
        }

        private void Send_Button_Click(object sender, EventArgs e)
        {
            client.WriteLineAndGetReply(Sending_TextBox.Text, TimeSpan.FromSeconds(0)); //was 3

            Main_TextBox.Text += "Sent: " + Sending_TextBox.Text + " " + "\n";
            Sending_TextBox.Text = "";
        }
*/

        private void MessengerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Stop();
            client.Close();
        }

        private void Connect_Button_Click(object sender, EventArgs e)
        {
            connect_state = !connect_state;

            if (connect_state == true)
            {
                Connect_Button.Text = "Connect";

                try
                {
                    client.Close();
                    //server.Stop();
                }
                catch (Exception ex)
                {
                    Connect_Button.Text = "Disconnect";
                    connect_state = !connect_state;
                    MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (connect_state == false)
            {
                Connect_Button.Text = "Disconnect";

                try
                {
                    //Starting Server
                    //IPAddress ip = IPAddress.Parse(GetLocalIPAddress());                    
                    //server.Start(ip, Convert.ToInt32(Port_TextBox.Text));

                    //Connect to server
                    client.Connect(IP_TextBox.Text, Convert.ToInt32(Port_TextBox.Text));
                }
                catch (Exception ex)
                {
                    Connect_Button.Text = "Connect";
                    connect_state = !connect_state;
                    MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
