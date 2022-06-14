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
    public partial class SystemSpecs : UserControl
    {
        private PCSpecs specs;
        public SystemSpecs(PCSpecs specs)
        {
            InitializeComponent();
            this.specs = specs;
        }

        private void SystemSpecs_Load(object sender, EventArgs e)
        {
            label2.Text += specs.PCName;
            label3.Text += specs.Manufacture;
            label4.Text += specs.Model;
            label5.Text += specs.CPU;
            label6.Text += specs.RAMSize + "MB";
            label7.Text += specs.VGAs;
            label8.Text += specs.OperatingSystem;
        }
    }
}
