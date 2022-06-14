using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ServerDashboard
{
    public partial class Screenshot : Form
    {
        private ClientCore core;

        public static Socket socket;
        public Socket client;
        private static EndPoint epRemote;
        private static bool init = false;
        private static int port = 12259;

        public Screenshot(ClientCore core)
        {
            InitializeComponent();
            this.core = core;
            
            if (!init)
            {
                epRemote = new IPEndPoint(IPAddress.Any, port);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(epRemote);
                socket.Listen(10);
                init = true;
            }

            core.SendMessage(3, "");
            client = socket.Accept();
        }

        private void Screenshot_Load(object sender, EventArgs e)
        {
            using (NetworkStream networkStream = new NetworkStream(client))
            using (FileStream fileStream = File.Open(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Temp\IMG_" + core.Name + ".jpg", FileMode.OpenOrCreate))
            {
                networkStream.CopyTo(fileStream);
            }
            pictureBox.ImageLocation = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Temp\IMG_" + core.Name + ".jpg";
            client.Close();
        }

        private void Screenshot_FormClosing(object sender, FormClosingEventArgs e) 
        {
            pictureBox.Dispose();
        }
    }
}
