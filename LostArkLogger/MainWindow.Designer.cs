namespace LostArkLogger
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.loggedPacketCountLabel = new System.Windows.Forms.Label();
            this.weblink = new System.Windows.Forms.LinkLabel();
            this.autoupload = new System.Windows.Forms.CheckBox();
            this.endRunButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loggedPacketCountLabel
            // 
            this.loggedPacketCountLabel.AutoSize = true;
            this.loggedPacketCountLabel.Location = new System.Drawing.Point(12, 44);
            this.loggedPacketCountLabel.Name = "loggedPacketCountLabel";
            this.loggedPacketCountLabel.Size = new System.Drawing.Size(100, 13);
            this.loggedPacketCountLabel.TabIndex = 2;
            this.loggedPacketCountLabel.Text = "Logged Packets : 0";
            // 
            // weblink
            // 
            this.weblink.AutoSize = true;
            this.weblink.Location = new System.Drawing.Point(225, 70);
            this.weblink.Name = "weblink";
            this.weblink.Size = new System.Drawing.Size(60, 13);
            this.weblink.TabIndex = 4;
            this.weblink.TabStop = true;
            this.weblink.Text = "by shalzuth";
            this.weblink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.weblink_LinkClicked);
            // 
            // autoupload
            // 
            this.autoupload.AutoSize = true;
            this.autoupload.Location = new System.Drawing.Point(12, 66);
            this.autoupload.Name = "autoupload";
            this.autoupload.Size = new System.Drawing.Size(83, 17);
            this.autoupload.TabIndex = 5;
            this.autoupload.Text = "Auto-upload";
            this.autoupload.UseVisualStyleBackColor = true;
            // 
            // endRunButton
            // 
            this.endRunButton.Location = new System.Drawing.Point(111, 62);
            this.endRunButton.Name = "endRunButton";
            this.endRunButton.Size = new System.Drawing.Size(75, 23);
            this.endRunButton.TabIndex = 6;
            this.endRunButton.Text = "End Run";
            this.endRunButton.UseVisualStyleBackColor = true;
            this.endRunButton.Click += new System.EventHandler(this.endRunButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 92);
            this.Controls.Add(this.endRunButton);
            this.Controls.Add(this.autoupload);
            this.Controls.Add(this.weblink);
            this.Controls.Add(this.loggedPacketCountLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Lost Ark Logger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label loggedPacketCountLabel;
        private System.Windows.Forms.LinkLabel weblink;
        private System.Windows.Forms.CheckBox autoupload;
        private System.Windows.Forms.Button endRunButton;
    }
}

