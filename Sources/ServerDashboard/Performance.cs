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
    public partial class Performance : UserControl
    {
        private Thread thread;
        private ClientCore core;

        public Performance(ClientCore core)
        {
            InitializeComponent();
            this.core = core;
        }

        private void Performance_Load(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(updatePerformace));
            thread.Start();
        }

        private delegate void Action(string s);
        private void logCPU(string s)
        {
            cpuTag.Text = s + "%";
        }
        private void logMEM(string s)
        {
            try
            {
                if (!core.exit) memTag.Text = (Convert.ToInt32(core.RAMSize) - Convert.ToInt32(s)).ToString() + @"MB/" + core.RAMSize + "MB";
            } 
            catch {}
        }

        private void updatePerformace()
        {
            while (true)
            {
                if (core.exit)
                {
                    if (core.Connected) core.SendMessage(4, "Close");
                    break;
                }

                string s = core.PerfInfo;
                if (s == null) continue;

                if (core.exit)
                {
                    core.SendMessage(4, "Close");
                    break;
                }

                if (this.cpuTag.InvokeRequired)
                {
                    if (core.exit)
                    {
                        core.SendMessage(4, "Close");
                        break;
                    }

                    try
                    {
                        Action d = new Action(logCPU);
                        this.Invoke(d, new object[] { s.Substring(0, s.IndexOf(' ')) });
                    }
                    catch { }

                    if (core.exit)
                    {
                        core.SendMessage(4, "Close");
                        break;
                    }
                } else logCPU(s.Substring(0, s.IndexOf(' ')));

                if (core.exit)
                {
                    if (core.Connected) core.SendMessage(4, "Close");
                    break;
                }

                s = s.Remove(0, s.IndexOf(' ') + 1);
                if (this.memTag.InvokeRequired)
                {
                    if (core.exit)
                    {
                        core.SendMessage(4, "Close");
                        break;
                    }

                    try
                    {
                        Action d = new Action(logMEM);
                        this.Invoke(d, new object[] { s });
                    }
                    catch { }

                if (core.exit)
                    {
                        core.SendMessage(4, "Close");
                        break;
                    }
                }
                else logMEM(s);

                if (core.exit)
                {
                    if (core.Connected) core.SendMessage(4, "Close");
                    break;
                }

                Thread.Sleep(700);
            }
        }
    }
}
