using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ServerDashboard
{
    public partial class AppSetting : Form
    {
        CentralData data = CentralData.Core;
        public AppSetting()
        {
            InitializeComponent();
        }

        private void AppSetting_Load(object sender, EventArgs e)
        {
            compSpecs.Checked = data.ShowSpecs;
            compPerf.Checked = data.ShowPerfStats;
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            data.ShowSpecs = compSpecs.Checked;
            data.ShowPerfStats = compPerf.Checked;

            data.ForceWrite();

            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox.Visible = true;
            button1.Enabled = false;
        }

        private void resetType()
        {
            oldPw.Text = "";
            newPw.Text = "";
            rePw.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CentralData.EncryptString(oldPw.Text) != data.Password || newPw.Text != rePw.Text)
            {
                MessageBox.Show("Incorrect typed information, please try again!", "Incorrect Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            data.Password = CentralData.EncryptString(newPw.Text);
            data.ForceWrite();

            MessageBox.Show("Password have been changed successfully!", "Password changed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            resetType();
            groupBox.Visible = false;
            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            resetType();
            groupBox.Visible = false;
            button1.Enabled = true;
        }
    }
}
