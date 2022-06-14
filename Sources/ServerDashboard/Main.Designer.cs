namespace ServerDashboard
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.unselectAllBtn = new System.Windows.Forms.Button();
            this.selectAllBtn = new System.Windows.Forms.Button();
            this.topText = new System.Windows.Forms.Label();
            this.clientControl = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lockBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.settingBtn = new System.Windows.Forms.Button();
            this.aboutBtn = new System.Windows.Forms.Button();
            this.shutDownBtn = new System.Windows.Forms.Button();
            this.power = new System.Windows.Forms.Button();
            this.takeAction = new System.Windows.Forms.Button();
            this.sendNotify = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.PictureBox();
            this.signalConnection = new System.ComponentModel.BackgroundWorker();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.topPanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.clientControl, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 681);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.SystemColors.HotTrack;
            this.topPanel.Controls.Add(this.unselectAllBtn);
            this.topPanel.Controls.Add(this.selectAllBtn);
            this.topPanel.Controls.Add(this.topText);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(200, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(808, 70);
            this.topPanel.TabIndex = 0;
            // 
            // unselectAllBtn
            // 
            this.unselectAllBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.unselectAllBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.unselectAllBtn.Location = new System.Drawing.Point(723, 15);
            this.unselectAllBtn.Name = "unselectAllBtn";
            this.unselectAllBtn.Size = new System.Drawing.Size(73, 39);
            this.unselectAllBtn.TabIndex = 2;
            this.unselectAllBtn.Text = "Unselect All";
            this.unselectAllBtn.UseVisualStyleBackColor = true;
            this.unselectAllBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // selectAllBtn
            // 
            this.selectAllBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.selectAllBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectAllBtn.Location = new System.Drawing.Point(644, 15);
            this.selectAllBtn.Name = "selectAllBtn";
            this.selectAllBtn.Size = new System.Drawing.Size(73, 39);
            this.selectAllBtn.TabIndex = 1;
            this.selectAllBtn.Text = "Select All";
            this.selectAllBtn.UseVisualStyleBackColor = true;
            this.selectAllBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // topText
            // 
            this.topText.BackColor = System.Drawing.Color.Transparent;
            this.topText.Dock = System.Windows.Forms.DockStyle.Left;
            this.topText.Font = new System.Drawing.Font("Source Sans Pro", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topText.ForeColor = System.Drawing.Color.White;
            this.topText.Location = new System.Drawing.Point(0, 0);
            this.topText.Name = "topText";
            this.topText.Size = new System.Drawing.Size(638, 70);
            this.topText.TabIndex = 0;
            this.topText.Text = "   Management Dashboard";
            this.topText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clientControl
            // 
            this.clientControl.AutoScroll = true;
            this.clientControl.BackColor = System.Drawing.Color.White;
            this.clientControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.clientControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientControl.Location = new System.Drawing.Point(200, 70);
            this.clientControl.Margin = new System.Windows.Forms.Padding(0);
            this.clientControl.Name = "clientControl";
            this.clientControl.Padding = new System.Windows.Forms.Padding(10);
            this.clientControl.Size = new System.Drawing.Size(808, 611);
            this.clientControl.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.panel2.Controls.Add(this.lockBtn);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.settingBtn);
            this.panel2.Controls.Add(this.aboutBtn);
            this.panel2.Controls.Add(this.shutDownBtn);
            this.panel2.Controls.Add(this.power);
            this.panel2.Controls.Add(this.takeAction);
            this.panel2.Controls.Add(this.sendNotify);
            this.panel2.Controls.Add(this.logo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(200, 681);
            this.panel2.TabIndex = 3;
            // 
            // lockBtn
            // 
            this.lockBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lockBtn.BackgroundImage = global::ServerDashboard.Properties.Resources.Lock_4x;
            this.lockBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lockBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lockBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.lockBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lockBtn.Location = new System.Drawing.Point(149, 628);
            this.lockBtn.Name = "lockBtn";
            this.lockBtn.Size = new System.Drawing.Size(40, 40);
            this.lockBtn.TabIndex = 8;
            this.lockBtn.Tag = "Lock Program";
            this.lockBtn.UseVisualStyleBackColor = true;
            this.lockBtn.Click += new System.EventHandler(this.lockBtn_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Source Sans Pro SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 602);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Program Controller";
            // 
            // settingBtn
            // 
            this.settingBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.settingBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("settingBtn.BackgroundImage")));
            this.settingBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.settingBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.settingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingBtn.Location = new System.Drawing.Point(57, 628);
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.Size = new System.Drawing.Size(40, 40);
            this.settingBtn.TabIndex = 6;
            this.settingBtn.Tag = "Server Setting";
            this.settingBtn.UseVisualStyleBackColor = true;
            this.settingBtn.Click += new System.EventHandler(this.settingBtn_Click);
            // 
            // aboutBtn
            // 
            this.aboutBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.aboutBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("aboutBtn.BackgroundImage")));
            this.aboutBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.aboutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aboutBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.aboutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutBtn.Location = new System.Drawing.Point(103, 628);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(40, 40);
            this.aboutBtn.TabIndex = 5;
            this.aboutBtn.Tag = "About Program";
            this.aboutBtn.UseVisualStyleBackColor = true;
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // shutDownBtn
            // 
            this.shutDownBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.shutDownBtn.BackgroundImage = global::ServerDashboard.Properties.Resources.Stop_4x;
            this.shutDownBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.shutDownBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shutDownBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.shutDownBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shutDownBtn.Location = new System.Drawing.Point(11, 628);
            this.shutDownBtn.Name = "shutDownBtn";
            this.shutDownBtn.Size = new System.Drawing.Size(40, 40);
            this.shutDownBtn.TabIndex = 3;
            this.shutDownBtn.Tag = "Stop the Server";
            this.shutDownBtn.UseVisualStyleBackColor = true;
            this.shutDownBtn.Click += new System.EventHandler(this.shutDownBtn_Click);
            // 
            // power
            // 
            this.power.BackgroundImage = global::ServerDashboard.Properties.Resources.Btn1_4x1;
            this.power.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.power.Cursor = System.Windows.Forms.Cursors.Hand;
            this.power.Location = new System.Drawing.Point(30, 408);
            this.power.Name = "power";
            this.power.Size = new System.Drawing.Size(140, 140);
            this.power.TabIndex = 4;
            this.power.UseVisualStyleBackColor = true;
            this.power.Click += new System.EventHandler(this.power_Click);
            // 
            // takeAction
            // 
            this.takeAction.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("takeAction.BackgroundImage")));
            this.takeAction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.takeAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.takeAction.Location = new System.Drawing.Point(30, 246);
            this.takeAction.Name = "takeAction";
            this.takeAction.Size = new System.Drawing.Size(140, 140);
            this.takeAction.TabIndex = 3;
            this.takeAction.UseVisualStyleBackColor = true;
            this.takeAction.Click += new System.EventHandler(this.takeAction_Click);
            // 
            // sendNotify
            // 
            this.sendNotify.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sendNotify.BackgroundImage")));
            this.sendNotify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sendNotify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendNotify.Location = new System.Drawing.Point(30, 83);
            this.sendNotify.Name = "sendNotify";
            this.sendNotify.Size = new System.Drawing.Size(140, 140);
            this.sendNotify.TabIndex = 2;
            this.sendNotify.UseVisualStyleBackColor = true;
            this.sendNotify.Click += new System.EventHandler(this.sendNotify_Click);
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(13, 9);
            this.logo.Margin = new System.Windows.Forms.Padding(0);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(145, 57);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 1;
            this.logo.TabStop = false;
            // 
            // signalConnection
            // 
            this.signalConnection.WorkerSupportsCancellation = true;
            this.signalConnection.DoWork += new System.ComponentModel.DoWorkEventHandler(this.signalConnection_DoWork);
            this.signalConnection.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.signalConnection_RunWorkerCompleted);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Manamutic Server";
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 681);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 720);
            this.Name = "Main";
            this.Text = "Manamutic - Server Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label topText;
        private System.ComponentModel.BackgroundWorker signalConnection;
        private System.Windows.Forms.FlowLayoutPanel clientControl;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Button unselectAllBtn;
        private System.Windows.Forms.Button selectAllBtn;
        private System.Windows.Forms.Button power;
        private System.Windows.Forms.Button takeAction;
        private System.Windows.Forms.Button sendNotify;
        private System.Windows.Forms.Button shutDownBtn;
        private System.Windows.Forms.Button aboutBtn;
        private System.Windows.Forms.Button settingBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button lockBtn;
    }
}

