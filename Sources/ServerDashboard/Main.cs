using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ServerDashboard
{
    public partial class Main : Form
    {
        private CentralData centralData = CentralData.Core;
        private ClientCore connectTemp;
        public static bool locker = false;

        public Main()
        {
            InitializeComponent();
        }

        private void signalConnection_DoWork(object sender, DoWorkEventArgs e)
        {
            connectTemp = new ClientCore();
            connectTemp.Notifier = notifyIcon;
            connectTemp.OpenConnection();
            Thread t = new Thread(() => { 
                while (!connectTemp.Connected) { }
            });

            t.Start();
            t.Join();
        }

        private void showTrayIcon()
        {
            notifyIcon.BalloonTipTitle = "Manamutic Server is running";
            notifyIcon.BalloonTipText = "You can click on tray icon or notification to show main dashboard";
            notifyIcon.ShowBalloonTip(3500);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            signalConnection.RunWorkerAsync();
        }

        private void signalConnection_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Thread.Sleep(3000);
            connectTemp.PCName = connectTemp.chatCore[0];
            connectTemp.Manufacture = connectTemp.chatCore[1];
            connectTemp.Model = connectTemp.chatCore[2];
            connectTemp.CPU = connectTemp.chatCore[3];
            connectTemp.RAMSize = connectTemp.chatCore[4];
            connectTemp.VGAs = connectTemp.chatCore[5];
            connectTemp.OperatingSystem = connectTemp.chatCore[6];
            
            connectTemp.Name = connectTemp.PCName;

            connectTemp.chatCore.Clear();

            notifyIcon.BalloonTipTitle = "Client Connected";
            notifyIcon.BalloonTipText = connectTemp.Name + " have been connected!";
            notifyIcon.ShowBalloonTip(3500);

            foreach (Client clientx in centralData.clients)
            {
                if (clientx.core.PCName == connectTemp.PCName)
                {
                    clientx.core = connectTemp;
                    clientx.Reconfig();
                    clientx.core.ConnectTrigger();
                    clientx.core.Connected = true;
                    connectTemp = null;
                    GC.Collect();
                    signalConnection.RunWorkerAsync();
                    return;
                }
            }

            centralData.clients.Add(new Client(connectTemp));
            this.clientControl.Controls.Add(centralData.clients.Last());

            connectTemp = null;
            signalConnection.RunWorkerAsync();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.CallShutDown)
            {
                this.Hide();
                e.Cancel = true;
                showTrayIcon();

                return;
            }

            e.Cancel = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Client clientx in centralData.clients)
            {
                clientx.checkBox.Checked = true;
            }
        }

        private int checkSelected()
        {
            int c = 0;
            foreach (Client clientx in centralData.clients)
            {
                if (clientx.checkBox.Checked) c++;
            }

            return c;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Client clientx in centralData.clients)
            {
                clientx.checkBox.Checked = false;
            }
        }

        private void sendNotify_Click(object sender, EventArgs e)
        {
            if (checkSelected() == 0)
            {
                MessageBox.Show("You haven't select any clients, please select before continue.", "No client selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NotificationAsk notification = new NotificationAsk();
            notification.ShowDialog();

            if (centralData.CheckNotify)
            {
                foreach (Client clientx in centralData.clients)
                    if (clientx.checkBox.Checked && clientx.core.Connected)
                        clientx.core.SendMessage(1, centralData.GetNotify);
            }
        }

        private void takeAction_Click(object sender, EventArgs e)
        {
            if (checkSelected() == 0)
            {
                MessageBox.Show("You haven't select any clients, please select before continue.", "No client selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            centralData.GetAction = "";

            ActionTake action = new ActionTake();
            action.ShowDialog();

            if (centralData.GetAction != "")
            {
                if (MessageBox.Show("WARNING: Do you want to continue with this ? Once this action have been done, it cannot be reverted.", "Confirm you choice!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) return;

                foreach (Client clientx in centralData.clients)
                    if (clientx.checkBox.Checked && clientx.core.Connected)
                        clientx.core.SendMessage(2, centralData.GetAction);
            }
        }

        private void power_Click(object sender, EventArgs e)
        {
            if (checkSelected() == 0)
            {
                MessageBox.Show("You haven't select any clients, please select before continue.", "No client selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            centralData.GetAction = "";

            PowerAction action = new PowerAction();
            action.ShowDialog();

            if (centralData.GetAction != "")
            {
                if (MessageBox.Show("WARNING: Do you want to continue with this ? Once this action have been done, it cannot be reverted.", "Confirm you choice!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) return;

                foreach (Client clientx in centralData.clients)
                    if (clientx.checkBox.Checked && clientx.core.Connected)
                        clientx.core.SendMessage(2, centralData.GetAction);
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void shutDownBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("WARNING: Exiting this program will cause connection problems to remaining clients, do you want to continue ?", "Exit Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result != DialogResult.OK)
            {
                return;
            }

            Program.CallShutDown = true;
            
            foreach (Client client in centralData.clients)
            {
                if (client.core.Connected) client.core.SendMessage(5, "");
            }

            Environment.Exit(0);

            foreach (Client client in centralData.clients)
            {
                if (client.core.Connected) client.core.client.Shutdown(System.Net.Sockets.SocketShutdown.Both);
            }
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (Program.TrayIcon)
            {
                this.Hide();
                showTrayIcon();
            }
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void settingBtn_Click(object sender, EventArgs e)
        {
            AppSetting setting = new AppSetting();
            setting.ShowDialog();
        }

        private void lockBtn_Click(object sender, EventArgs e)
        {
            if (!locker)
            {
                lockBtn.BackgroundImage = ServerDashboard.Properties.Resources.Unlock_4x;
                topPanel.BackColor = Color.DarkRed;
                topText.Text = "   Dashboard have been locked";
                locker = !locker;
            } 
            else
            {
                // Ask Password here;
                PasswordAsk ask = new PasswordAsk();
                ask.ShowDialog();
                if (locker) return;

                lockBtn.BackgroundImage = ServerDashboard.Properties.Resources.Lock_4x;
                topPanel.BackColor = SystemColors.HotTrack;
                topText.Text = "   Management Dashboard";
            }

            sendNotify.Enabled = !locker;
            takeAction.Enabled = !locker;
            power.Enabled = !locker;
            shutDownBtn.Enabled = !locker;
            settingBtn.Enabled = !locker;
            unselectAllBtn.Enabled = !locker;
            selectAllBtn.Enabled = !locker;
            clientControl.Enabled = !locker;
        }
    }
}
