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
            client = new SimpleTcpClient("127.0.0.1:9000");
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
        
    }
}
