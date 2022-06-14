using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Management;

namespace Client
{
    public partial class Main : Form
    {
        // Perfomance Info
        private static PerformanceCounter cpuCounter;
        private static PerformanceCounter ramCounter;

        public static IPAddress IP { get; set; }
        public static bool denied = true;

        IPEndPoint imgEP;
        Socket imgClient;

        public Socket sck;
        public EndPoint epLocal, epRemote;
        public Stream stream;

        public byte[] buffer;

        public Main()
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            InitializeComponent();
        }

        private static string getCurrentCpuUsage()
        {
            return Math.Round(cpuCounter.NextValue()).ToString();
        }

        private static string getAvailableRAM()
        {
            return ramCounter.NextValue().ToString();
        }

        private static string getPerformaceInfo()
        {
            return getCurrentCpuUsage() + " " + getAvailableRAM();
        }

        private void SendMessage(int type, string message = "")
        {
            Encoding aEncode = new UTF8Encoding();
            byte[] convertedData = new byte[2048];
            try
            {
                if (type == 0)
                {
                    convertedData = aEncode.GetBytes("B0 " + message);
                    sck.Send(convertedData);
                }
                else if (type == 1)
                {
                    convertedData = aEncode.GetBytes("B1 " + getPerformaceInfo());
                    sck.Send(convertedData);
                }
                else if (type == 2)
                {
                    convertedData = aEncode.GetBytes("B2 " + message);
                    sck.Send(convertedData);
                }
            } 
            catch (Exception ex)
            {
                if (threadx.IsAlive) threadx.Abort();
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (messageBox.Text == "") return;

            SendMessage(0, messageBox.Text);

            chatLog.AppendText("Me: " + messageBox.Text);
            chatLog.AppendText(Environment.NewLine);

            messageBox.Text = "";
        }

        private void getLogin()
        {
            Login login = new Login();
            login.ShowDialog();
        }

        private void connectTo()
        {
            try
            {
                sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                imgEP = new IPEndPoint(IP, 12259);

                epLocal = new IPEndPoint(IPAddress.Any, 12258);
                sck.Bind(epLocal);

                epRemote = new IPEndPoint(IP, 12258);
                sck.Connect(epRemote);

                buffer = new byte[2048];

                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);

                SendMessage(2, PCSpecs.PCName);
                Thread.Sleep(350);
                SendMessage(2, PCSpecs.Manufacture);
                Thread.Sleep(350);
                SendMessage(2, PCSpecs.Model);
                Thread.Sleep(350);
                SendMessage(2, PCSpecs.CPU);
                Thread.Sleep(350);
                SendMessage(2, (PCSpecs.RAMSize / 1024).ToString());
                Thread.Sleep(350);
                SendMessage(2, PCSpecs.VGAs);
                Thread.Sleep(350);
                SendMessage(2, PCSpecs.OperatingSystem);
                Thread.Sleep(350);

                File.WriteAllText(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\config.cfg", IP.ToString());

                notifyIcon.Icon = new Icon(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Icon@4xLow.ico");
                notifyIcon.Text = "Manamutic Client - Connected to " + IP.ToString();

                MessageBox.Show("Connected to " + IP.ToString() + " successfully", "Connection completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                messageBox.Enabled = true;
                sendButton.Enabled = true;
                connectBtn.Enabled = false;
            }
            catch (Exception ex)
            {
                if (File.Exists(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\config.cfg")) 
                    File.Delete(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\config.cfg");
                MessageBox.Show(ex.Message.ToString(), "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            getLogin();
            if (denied) return;
            connectTo();
        }

        private void sendPerf() 
        {
            while (true) { SendMessage(1); Thread.Sleep(500); } 
        }
        Thread threadx;

        private delegate void Action1();
        private delegate void Action2(string s);

        private void addChatLog(string s)
        {
            chatLog.AppendText(s);
        }

        private void addLine()
        {
            chatLog.AppendText(Environment.NewLine);
        }

        private void MessageCallBack(IAsyncResult asyncResult)
        {
            threadx = new Thread(new ThreadStart(sendPerf));

            try
            {
                byte[] receiveData = new byte[2048];
                receiveData = (byte[])asyncResult.AsyncState;

                Encoding aEncode = new UTF8Encoding();
                string convertedData = aEncode.GetString(receiveData);
                convertedData = convertedData.Replace("\0", string.Empty);

                if (convertedData.Substring(0, 2) == "A0")
                {
                    // Chat
                    convertedData = convertedData.Remove(0, 3);

                    if (chatLog.InvokeRequired)
                    {
                        Action2 d1 = new Action2(addChatLog);
                        this.Invoke(d1, new object[] { "Server: " + convertedData });

                        Action d2 = new Action(addLine);
                        this.Invoke(d2, new object[] {});
                    }
                    else
                    {
                        chatLog.AppendText("Server: " + convertedData);
                        chatLog.AppendText(Environment.NewLine);
                    }

                    notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon.BalloonTipTitle = "Server Message";
                    notifyIcon.BalloonTipText = convertedData;
                    notifyIcon.ShowBalloonTip(3500);
                }
                else if (convertedData.Substring(0, 2) == "A1")
                {
                    convertedData = convertedData.Remove(0, 3);

                    if (chatLog.InvokeRequired)
                    {
                        Action2 d1 = new Action2(addChatLog);
                        this.Invoke(d1, new object[] { "SERVER NOTIFICATION: " + convertedData });

                        Action d2 = new Action(addLine);
                        this.Invoke(d2, new object[] { });
                    }
                    else
                    {
                        chatLog.AppendText("SERVER NOTIFICATION: " + convertedData);
                        chatLog.AppendText(Environment.NewLine);
                    }

                    notifyIcon.BalloonTipIcon = ToolTipIcon.Warning;
                    notifyIcon.BalloonTipTitle = "Server Notification";
                    notifyIcon.BalloonTipText = convertedData;
                    notifyIcon.ShowBalloonTip(3500);
                    
                }
                else if (convertedData.Substring(0, 2) == "A2")
                {
                    convertedData = convertedData.Remove(0, 3);

                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C " + convertedData;
                    process.StartInfo = startInfo;
                    process.Start();
                }
                else if (convertedData.Substring(0, 2) == "A3")
                {
                    // Send to port 12259
                    imgClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    imgClient.BeginConnect(imgEP, new AsyncCallback(imgTo), imgClient);
                }
                else if (convertedData.Substring(0, 2) == "A4")
                {
                    // Send performace stats
                    convertedData = convertedData.Remove(0, 3);
                    if (convertedData == "Open")
                    {
                        threadx.Start();
                    } 
                    else if (convertedData == "Close")
                    {
                        threadx.Abort();
                    }
                }
                else if (convertedData.Substring(0, 2) == "A5")
                {
                    // Close socket
                    if (threadx.IsAlive) threadx.Abort();
                    sck.Close();

                    MessageBox.Show("Server closed, this program will shut down now!", "Server closed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Environment.Exit(0);

                    return;
                }

                buffer = new byte[2048];

                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);

            }
            catch (Exception ex)
            {
                if (threadx.IsAlive) threadx.Abort();
                MessageBox.Show(ex.Message.ToString());
                Environment.Exit(0);
            }
        }

        private void imgTo(IAsyncResult ar)
        {
            Image bm = getScreenshot();
            bm.Save(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\IMG_" + PCSpecs.PCName + ".jpg", ImageFormat.Jpeg);

            // Retrieve the socket from the state object.  
            Socket client = (Socket)ar.AsyncState;

            // Complete the connection.  
            client.EndConnect(ar);
            client.SendFile(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\IMG_" + PCSpecs.PCName + ".jpg");

            imgClient.Shutdown(SocketShutdown.Both);
            imgClient.Close();

            File.Delete(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\IMG_" + PCSpecs.PCName + ".jpg");

            return;
        }

        private Image getScreenshot()
        {
            Bitmap bm = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(bm);
            g.CopyFromScreen(0, 0, 0, 0, bm.Size);
            return bm;
        }

        private void messageBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PCInformation fx = new PCInformation();
            fx.ShowDialog();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sck != null && sck.Connected)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (!File.Exists(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\config.cfg"))
            {
                getLogin();
            }
            else
            {
                string[] filex = File.ReadAllLines(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\config.cfg");
                IP = IPAddress.Parse(filex[0]);
                denied = false;
            }

            if (denied) return;
            connectTo();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            notifyIcon.Icon = new Icon(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Alert@4xLow.ico");
            notifyIcon.Text = "Manamutic Client - Not Connected";

            ManagementObjectSearcher mos;

            mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            foreach (ManagementObject managementObject in mos.Get())
            {
                PCSpecs.OperatingSystem = managementObject["Caption"].ToString();   //Display operating system caption
                PCSpecs.RAMSize = Convert.ToInt64(managementObject["TotalVisibleMemorySize"].ToString());
                break;
            }

            mos = new ManagementObjectSearcher("select * from Win32_Processor");
            foreach (ManagementObject managementObject in mos.Get())
            {
                PCSpecs.CPU = managementObject["Name"].ToString();   //Display operating system caption
                break;
            }

            PCSpecs.VGAs = "";
            mos = new ManagementObjectSearcher("select * from Win32_VideoController");
            foreach (ManagementObject managementObject in mos.Get())
            {
                PCSpecs.VGAs += managementObject["Name"].ToString() + ", ";   //Display operating system caption
                
            }
            PCSpecs.VGAs = PCSpecs.VGAs.Remove(PCSpecs.VGAs.Length - 2, 2);

            mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            foreach (ManagementObject managementObject in mos.Get())
            {
                PCSpecs.Manufacture = managementObject["Manufacturer"].ToString();
                break;
            }

            mos = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            foreach (ManagementObject managementObject in mos.Get())
            {
                PCSpecs.PCName = managementObject["Name"].ToString();
                PCSpecs.Model = managementObject["Model"].ToString();
                break;
            }
        }
    }
}
