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
    public partial class PowerAction : Form
    {
        private CentralData data = CentralData.Core;
        public PowerAction()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Shut Down")
            {
                data.GetAction = @"shutdown -s -t 15";
            } 
            else if (comboBox1.Text == "Restart")
            {
                data.GetAction = @"shutdown -r -t 15";
            }
            else if (comboBox1.Text == "Log Off")
            {
                data.GetAction = @"shutdown -l -t 15";
            }

            this.Close();
        }
    }
}
