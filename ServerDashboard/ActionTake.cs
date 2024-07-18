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
    public partial class ActionTake : Form
    {
        private CentralData data = CentralData.Core;
        public ActionTake()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                data.GetAction = @"wuauclt /detectnow";
            } else if (radioButton2.Checked)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("You haven't type any action!", "No action typed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                data.GetAction = textBox1.Text;
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox1.Enabled = true;
            } else
            {
                textBox1.Enabled = false;
            }
        }
    }
}
