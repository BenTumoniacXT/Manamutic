using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace ServerDashboard
{
    public sealed class CentralData
    {
        private static string key = "b25ca7598a4c5123cba5e2a2893a4196";
        public string Password;
        public static string EncryptString(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public delegate void GlobalAction(); 
        private static CentralData core = null;
        private CentralData() 
        {
            clients = new List<Client>();
            CheckNotify = false;

            // Load Setting
            string s = File.ReadAllText(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\setting.cfg");
            string[] sx = s.Split(' ');

            if (sx[0] == "1") ShowSpecs = true;
            else ShowSpecs = false;

            if (sx[1] == "1") ShowPerfStats = true;
            else ShowPerfStats = false;

            Password = sx[2];
        }

        public static CentralData Core 
        { 
            get 
            {
                if (core == null)
                {
                    core = new CentralData();  
                }
                return core; 
            } 
        }

        public List<Client> clients;

        public string GetName { get; set; }
        public string GetNotify { get; set; }
        public string GetAction { get; set; }
        public bool CheckNotify { get; set; }

        public bool ShowSpecs;
        public bool ShowPerfStats;
    
        public void ForceWrite()
        {
            string s;
            if (ShowSpecs) s = "1 ";
            else s = "0 ";

            if (ShowPerfStats) s += "1 ";
            else s += "0 ";

            s += Password;

            File.WriteAllText(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\setting.cfg", s);
        }
    }
}
