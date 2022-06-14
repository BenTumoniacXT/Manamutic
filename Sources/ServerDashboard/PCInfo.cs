using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ServerDashboard
{
    public partial class PCInfo : Form
    {
        private ClientCore core;
        private CentralData centralData = CentralData.Core;
        public PCInfo(ClientCore core)
        {
            InitializeComponent();
            this.core = core;
            this.core.exit = false;
        }

        private void PCInfo_Load(object sender, EventArgs e)
        {
            if (core.Accessed) this.Close();

            core.Accessed = true;
            this.pcName.Text = core.Name + " - Client Dashboard";
            
            if (centralData.ShowSpecs) this.flowLayoutPanel1.Controls.Add(new SystemSpecs(core));

            if (centralData.ShowPerfStats)
            {
                this.core.SendMessage(4, "Open");
                this.flowLayoutPanel1.Controls.Add(new Performance(core));
            }

            this.flowLayoutPanel1.Controls.Add(new ClientChat(core));
        }

        private void PCInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            core.Accessed = false;
            core.exit = true;
            core.MessageTrigger = () => { };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            core.SendMessage(2, @"wuauclt /detectnow");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NotificationAsk notification = new NotificationAsk();
            notification.ShowDialog();

            if (centralData.CheckNotify)
            {
                core.SendMessage(1, centralData.GetNotify);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("WARNING: Do you want to continue with this ? Once this action have been done, it cannot be reverted.", "Confirm you choice!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) return;
            core.SendMessage(2, @"shutdown -s -t 15");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("WARNING: Do you want to continue with this ? Once this action have been done, it cannot be reverted.", "Confirm you choice!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) return;
            core.SendMessage(2, @"shutdown -r -t 15");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Screenshot screenshot = new Screenshot(core);
            screenshot.ShowDialog();
        }
    }
}
