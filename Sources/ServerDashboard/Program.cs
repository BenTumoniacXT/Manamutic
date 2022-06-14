using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace ServerDashboard
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static Mutex mutex = null;
        public static bool TrayIcon = false;
        public static bool CallShutDown = false;
        [STAThread]

        static void Main(string[] args)
        {
            const string appName = "ManamuticServer";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                MessageBox.Show("This application is running!", "Application already executed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (args.Length != 0 && args[0] == "-trayicon") TrayIcon = true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
