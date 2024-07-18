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
    public partial class ClientChat : UserControl
    {
        private ClientCore core;
        private Thread message;
        public ClientChat(ClientCore core)
        {
            InitializeComponent();
            this.core = core;
            this.core.MessageTrigger = addMessageCore;
        }

        private void AddMessageNew()
        {
            chatLog.AppendText(core.chatCore.Last());
            chatLog.AppendText(Environment.NewLine);
        }

        private delegate void MessageCall();

        private Thread addMessage;

        private void addMessageCore()
        {
            if (this.chatLog.InvokeRequired)
            {
                MessageCall d = new MessageCall(AddMessageNew);
                this.Invoke(d, new object[] { });
            }
            else AddMessageNew();
        }

        /*private void checkMessage()
        {
            addMessage = new Thread(new ThreadStart(addMessageCore));
            while (true)
            {
                if (core.exit) break;
                if (core.changed)
                {
                    if (addMessage.IsAlive) addMessage.Join();
                    core.changed = false;
                    addMessage = new Thread(new ThreadStart(addMessageCore));
                    addMessage.Start();
                }

                if (core.exit) break;
            }
        }*/

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (messageBox.Text == "") return;
            
            core.SendMessage(0, messageBox.Text);
            chatLog.AppendText("Server: " + messageBox.Text);
            chatLog.AppendText(Environment.NewLine);
            core.chatCore.Add("Server: " + messageBox.Text);

            messageBox.Text = "";
        }

        private void ClientChat_Load(object sender, EventArgs e)
        {
            foreach (string chat in core.chatCore)
            {
                chatLog.AppendText(chat);
                chatLog.AppendText(Environment.NewLine);
            }
            // message = new Thread(new ThreadStart(checkMessage));
            // message.Start();
        }
    }
}
