#region Assembly SimpleTcp, Version=2.4.1.2, Culture=neutral, PublicKeyToken=null
// C:\Users\Nick Hoschke\.nuget\packages\supersimpletcp\2.4.1.2\lib\net5.0\SimpleTcp.dll
#endregion

using SimpleTcp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace WinSchiffeVersenken
{
    class NetworkClient
    {
        private Form1 main;
        private bool connected;
        SimpleTcpClient client;

        public NetworkClient(Form1 main)
        {
            this.main = main;
            connected = false;
            client = new SimpleTcpClient("bueroprojekt.ddns.net:1024");
            client.Events.Connected += Events_Connected;
            //client.Events.DataReceived += Events_DataRecieved;
            client.Events.DataReceived += main.DataReceived;
            client.Events.Disconnected += Events_Disconnected;
        }

        private void Events_Disconnected(object sender, ClientDisconnectedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Events_DataRecieved(object sender, DataReceivedEventArgs e)
        {
            Message m = FromByteArray<Message>(e.Data);
        }

        private void Events_Connected(object sender, ClientConnectedEventArgs e)
        {
            main.Invoke((MethodInvoker)delegate
            {
                connected = true;
            });
        }

        public bool isConnected()
        {
            return connected;
        }

        public void sendSerialized(Message m)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var s = new MemoryStream())
            {
                formatter.Serialize(s, m);
                client.Send(s.ToArray());
            }
                
        }

        public static T FromByteArray<T>(byte[] data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream s = new MemoryStream(data))
            {
                object o = formatter.Deserialize(s);
                return (T)o;
            }
        }

        public void connect()
        {
            client.Connect();
        }
        
        /*
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client.Connect();
                btnSend.Enabled = true;
                btnConnect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            client.Send(username);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new(txtIP.Text);
            client.Events.Connected += Events_Connected;
            client.Events.DataReceived += Events_DataRecieved;
            client.Events.Disconnected += Events_Disconnected;
            btnSend.Enabled = false;
        }


        private void Events_Disconnected(object sender, ClientDisconnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"Server disconnected.{Environment.NewLine}";
            });
        }

        private void Events_DataRecieved(object sender, DataReceivedEventArgs e)
        {
            if (abfangen == 0)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    gegner = Encoding.UTF8.GetString(e.Data);
                    txtInfo.Text += $"Gegner: {gegner}{Environment.NewLine}";
                    abfangen++;
                });
            }
            else
            {
                if (ticker == 0)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        rx = Convert.ToInt32(Encoding.UTF8.GetString(e.Data));
                        ticker = 1;
                        txtInfo.Text += $"rx: {rx}{Environment.NewLine}";
                    });
                }
                else if (ticker == 1)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        ry = Convert.ToInt32(Encoding.UTF8.GetString(e.Data));
                        ticker = 0;
                        txtInfo.Text += $"ry: {ry}{Environment.NewLine}";
                        treffer = 1;
                        client.Send(Convert.ToString(treffer));
                    });
                }
                else if ((ticker == 2) && (Convert.ToInt32(Encoding.UTF8.GetString(e.Data)) == 1))
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        txtInfo.Text += $"Treffer!{Environment.NewLine}";
                        ticker = 0;
                    });
                }
            }
        }

        private void Events_Connected(object sender, ClientConnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"Server connected.{Environment.NewLine}";
            });
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            kx = 2;
            ky = 3;
            if (client.IsConnected)
            {
                if (ticker_s == 0)
                {
                    txtMessage.Text = Convert.ToString(kx);

                    if (!string.IsNullOrEmpty(txtMessage.Text))
                    {
                        client.Send(txtMessage.Text);
                        txtInfo.Text += $"Me(kx): {txtMessage.Text}{Environment.NewLine}";
                        txtMessage.Text = string.Empty;
                    }
                    ticker_s = 1;
                }
                else
                {
                    txtMessage.Text = Convert.ToString(ky);

                    if (!string.IsNullOrEmpty(txtMessage.Text))
                    {
                        client.Send(txtMessage.Text);
                        txtInfo.Text += $"Me(ky): {txtMessage.Text}{Environment.NewLine}";
                        txtMessage.Text = string.Empty;
                    }
                    ticker_s = 0;
                    ticker = 2;
                }
            }
        }
        */
    }
}
