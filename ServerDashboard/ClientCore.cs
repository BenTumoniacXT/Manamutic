using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ServerDashboard
{
    public class ClientCore : PCSpecs
    {
        private static CentralData centralData = CentralData.Core;
        public static int machine = 0;
        public string Name { get; set; }

        public NotifyIcon Notifier;
        public CentralData.GlobalAction ConnectTrigger = () => { };
        public CentralData.GlobalAction DisconnectTrigger = () => { };
        public CentralData.GlobalAction MessageTrigger = () => { };

        public List<string> chatCore;
        public bool exit = true;
        public string PerfInfo;
        public bool Accessed = false;

        // For Network
        public static Socket socket;
        public Socket client;
        private byte[] buffer;
        private static EndPoint epRemote;
        private static int port = 12258;
        private static bool initialized = false;

        public bool Connected { get; set; }

        public ClientCore()
        {
            Connected = false;
            chatCore = new List<string>();

            if (!initialized)
            {
                epRemote = new IPEndPoint(IPAddress.Any, port);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(epRemote);
                socket.Listen(10);
                initialized = true;
            }
        }

        public void OpenConnection()
        {
            try
            {
                socket.BeginAccept(new AsyncCallback(AcceptCallback), socket);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            Socket listener = (Socket)ar.AsyncState;
            client = listener.EndAccept(ar);

            buffer = new byte[2048];

            client.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            Connected = true;
        }

        private void MessageCallBack(IAsyncResult asyncResult)
        {
            try
            {
                byte[] receiveData = new byte[2048];
                receiveData = (byte[])asyncResult.AsyncState;

                Encoding aEncode = new UTF8Encoding();
                string convertedData = aEncode.GetString(receiveData);
                convertedData = convertedData.Replace("\0", string.Empty);

                // Do something with Converted Data

                if (convertedData.Substring(0, 2) == "B0")
                {
                    convertedData = convertedData.Remove(0, 3);

                    chatCore.Add(Name + ": " + convertedData);
                    MessageTrigger();

                    if (Name != "")
                    {
                        Notifier.BalloonTipText = convertedData;
                        Notifier.BalloonTipTitle = Name;
                        Notifier.ShowBalloonTip(7000);
                    }
                }
                else if (convertedData.Substring(0, 2) == "B1")
                {
                    convertedData = convertedData.Remove(0, 3);
                    PerfInfo = convertedData;
                }
                if (convertedData.Substring(0, 2) == "B2")
                {
                    convertedData = convertedData.Remove(0, 3);
                    chatCore.Add(convertedData);
                }

                buffer = new byte[2048];
                client.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);

            }
            catch 
            {
                Connected = false;
                Notifier.BalloonTipTitle = "Client disconnected";
                Notifier.BalloonTipText = Name + " have been disconnected!";
                Notifier.ShowBalloonTip(3500);

                DisconnectTrigger();
            }
        }

        public void SendMessage(int type, string info)
        {
            Encoding aEncode = new UTF8Encoding();
            byte[] convertedData = new byte[2048];
            convertedData = aEncode.GetBytes("A" + type.ToString() + " " + info);
            client.Send(convertedData);
        }
    }
}
