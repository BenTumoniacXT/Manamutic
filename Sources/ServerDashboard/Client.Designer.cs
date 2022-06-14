namespace ServerDashboard
{
    partial class Client
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusPanel = new System.Windows.Forms.Panel();
            this.pcName = new System.Windows.Forms.Label();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // statusPanel
            // 
            this.statusPanel.BackColor = System.Drawing.Color.LimeGreen;
            this.statusPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusPanel.Location = new System.Drawing.Point(0, 0);
            this.statusPanel.Margin = new System.Windows.Forms.Padding(0);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(230, 10);
            this.statusPanel.TabIndex = 2;
            // 
            // pcName
            // 
            this.pcName.Font = new System.Drawing.Font("Source Sans Pro", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pcName.ForeColor = System.Drawing.Color.White;
            this.pcName.Location = new System.Drawing.Point(13, 205);
            this.pcName.Name = "pcName";
            this.pcName.Size = new System.Drawing.Size(204, 67);
            this.pcName.TabIndex = 3;
            this.pcName.Text = "PC Name";
            this.pcName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pcName.Click += new System.EventHandler(this.logo_Click);
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox.ForeColor = System.Drawing.Color.White;
            this.checkBox.Location = new System.Drawing.Point(7, 279);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(68, 17);
            this.checkBox.TabIndex = 4;
            this.checkBox.Text = "Selected";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(144, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 21);
            this.button1.TabIndex = 5;
            this.button1.Text = "Change Name";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // logo
            // 
            this.logo.Image = global::ServerDashboard.Properties.Resources.Client_4x;
            this.logo.Location = new System.Drawing.Point(22, 20);
            this.logo.Margin = new System.Windows.Forms.Padding(0);
            this.logo.Name = "logo";
            this.logo.Padding = new System.Windows.Forms.Padding(10);
            this.logo.Size = new System.Drawing.Size(187, 185);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            this.logo.Click += new System.EventHandler(this.logo_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.pcName);
            this.Controls.Add(this.statusPanel);
            this.Controls.Add(this.logo);
            this.Name = "Client";
            this.Size = new System.Drawing.Size(230, 300);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Label pcName;
        public System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Button button1;
    }
}
