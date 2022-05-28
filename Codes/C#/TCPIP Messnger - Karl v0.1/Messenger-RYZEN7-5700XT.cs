using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net; //to get ip
using System.Net.Sockets;
using TCPIP_Messnger___Karl_v0._1.Properties;

namespace TCPIP_Messnger___Karl_v0._1
{    
    public partial class MessengerForm : Form
    {
        //WORKS BUT LOST INTEREST AND DIDN'T POLISH

        SimpleTcpServer server;
        SimpleTcpClient client;
        bool connect_state = true;

        public MessengerForm()
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

        private void MessengerForm_Load(object sender, EventArgs e)
        {
            //Server stuff
            server = new SimpleTcpServer();
            server.Delimiter = 0x13;//enter
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;

            //Starting Server
            IPAddress ip = IPAddress.Parse(GetLocalIPAddress());
            //IPAddress ip = IPAddress.Parse(GetPublicIP());
            server.Start(ip, Convert.ToInt32("23"));

            //FOR FASTER TESTING
            IP_TextBox.Text = GetLocalIPAddress();
            Port_TextBox.Text = "23";           

            //Starting Client
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataReceived;
        }
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

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            //NEED FORMATING

            //Update message to txtStatus
            Main_TextBox.Invoke((MethodInvoker)delegate ()
            {
                Main_TextBox.Text += e.MessageString;
                Main_TextBox.ForeColor = Color.Blue;
            });
        }

        private void MessengerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server.IsStarted)
                server.Stop();

            client.Dispose();
            client.Disconnect();
        }

        private void Connect_Button_Click(object sender, EventArgs e)
        {            
            connect_state = !connect_state;

            if (connect_state == true)
            {
                Connect_Button.Text = "Connect";

                try
                {
                    client.Disconnect();
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

        private void Send_Button_Click(object sender, EventArgs e)
        {
            client.WriteLineAndGetReply(Sending_TextBox.Text, TimeSpan.FromSeconds(3));
        }

        private void Title_Label_Click(object sender, EventArgs e)
        {

        }
    }
}
