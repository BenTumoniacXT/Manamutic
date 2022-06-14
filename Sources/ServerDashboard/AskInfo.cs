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
    public partial class AskInfo : Form
    {
        public AskInfo()
        {
            InitializeComponent();
        }

        private void AskInfo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CentralData centralData = CentralData.Core;
            centralData.GetName = this.textBox1.Text;
            this.Close();
        }
    }
}
