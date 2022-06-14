using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class PCInformation : Form
    {
        public PCInformation()
        {
            InitializeComponent();
        }

        private void PCInformation_Load(object sender, EventArgs e)
        {
            label2.Text += PCSpecs.PCName;
            label3.Text += PCSpecs.Manufacture;
            label4.Text += PCSpecs.Model;
            label5.Text += PCSpecs.CPU;
            label6.Text += (PCSpecs.RAMSize / 1024).ToString() + "MB";
            label7.Text += PCSpecs.VGAs;
            label8.Text += PCSpecs.OperatingSystem;
        }
    }
}
