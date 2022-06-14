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
    public partial class PasswordAsk : Form
    {
        CentralData core = CentralData.Core;
        public PasswordAsk()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string encrypted = CentralData.EncryptString(textBox1.Text);
            if (core.Password != encrypted)
            {
                MessageBox.Show("Password incorrect, please try again!", "Incorrect password!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Main.locker = false;
            this.Close();
        }
    }
}
