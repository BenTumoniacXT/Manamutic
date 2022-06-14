using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerDashboard
{
    public partial class Client : UserControl
    {
        public ClientCore core;
        public Client(ClientCore core)
        {
            InitializeComponent();
            this.core = core;
            this.pcName.Text = core.Name;
            Reconfig();
        }

        public void Reconfig()
        {
            core.ConnectTrigger = triggerConnected;
            core.DisconnectTrigger = triggerDisconnected;
        }

        private void logo_Click(object sender, EventArgs e)
        {
            if (!this.core.Connected)
            {
                MessageBox.Show("This client is disconnected", "Disconnected Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PCInfo core = new PCInfo(this.core);
            core.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AskInfo askInfo = new AskInfo();
            askInfo.ShowDialog();

            CentralData data = CentralData.Core;
            if (data.GetName != "")
            {
                core.Name = data.GetName;
                this.pcName.Text = core.Name;
            }
        }

        private void triggerDisconnected()
        {
            statusPanel.BackColor = Color.Red;
        }

        private void triggerConnected()
        {
            statusPanel.BackColor = Color.LimeGreen;
        }
    }
}
