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
            this.overlayEnabled = new System.Windows.Forms.CheckBox();
            this.debugLog = new System.Windows.Forms.CheckBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.checkUpdate = new System.Windows.Forms.Button();
            this.sniffModeCheckbox = new System.Windows.Forms.CheckBox();
            this.regionSelector = new System.Windows.Forms.ComboBox();
            this.autoUpload = new System.Windows.Forms.CheckBox();
            this.displayName = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // loggedPacketCountLabel
            // 
            this.loggedPacketCountLabel.AutoSize = true;
            this.loggedPacketCountLabel.Location = new System.Drawing.Point(13, 10);
            this.loggedPacketCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.loggedPacketCountLabel.Name = "loggedPacketCountLabel";
            this.loggedPacketCountLabel.Size = new System.Drawing.Size(100, 13);
            this.loggedPacketCountLabel.TabIndex = 2;
            this.loggedPacketCountLabel.Text = "Logged Packets : 0";
            // 
            // weblink
            // 
            this.weblink.AutoSize = true;
            this.weblink.Location = new System.Drawing.Point(177, 10);
            this.weblink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.weblink.Name = "weblink";
            this.weblink.Size = new System.Drawing.Size(60, 13);
            this.weblink.TabIndex = 4;
            this.weblink.TabStop = true;
            this.weblink.Text = "by shalzuth";
            this.weblink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.weblink_LinkClicked);
            // 
            // overlayEnabled
            // 
            this.overlayEnabled.AutoSize = true;
            this.overlayEnabled.Checked = true;
            this.overlayEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.overlayEnabled.Location = new System.Drawing.Point(11, 26);
            this.overlayEnabled.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.overlayEnabled.Name = "overlayEnabled";
            this.overlayEnabled.Size = new System.Drawing.Size(62, 17);
            this.overlayEnabled.TabIndex = 5;
            this.overlayEnabled.Text = "Overlay";
            this.overlayEnabled.UseVisualStyleBackColor = true;
            this.overlayEnabled.CheckedChanged += new System.EventHandler(this.overlayEnabled_CheckedChanged);
            // 
            // debugLog
            // 
            this.debugLog.AutoSize = true;
            this.debugLog.Location = new System.Drawing.Point(93, 36);
            this.debugLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.debugLog.Name = "debugLog";
            this.debugLog.Size = new System.Drawing.Size(58, 17);
            this.debugLog.TabIndex = 9;
            this.debugLog.Text = "Debug";
            this.debugLog.UseVisualStyleBackColor = true;
            this.debugLog.CheckedChanged += new System.EventHandler(this.debugLog_CheckedChanged);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(195, 97);
            this.versionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(46, 13);
            this.versionLabel.TabIndex = 10;
            this.versionLabel.Text = "v1.0.0.0";
            // 
            // checkUpdate
            // 
            this.checkUpdate.Location = new System.Drawing.Point(73, 90);
            this.checkUpdate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkUpdate.Name = "checkUpdate";
            this.checkUpdate.Size = new System.Drawing.Size(114, 27);
            this.checkUpdate.TabIndex = 11;
            this.checkUpdate.Text = "Check Update";
            this.checkUpdate.UseVisualStyleBackColor = true;
            this.checkUpdate.Click += new System.EventHandler(this.checkUpdate_Click);
            // 
            // sniffModeCheckbox
            // 
            this.sniffModeCheckbox.AutoSize = true;
            this.sniffModeCheckbox.Location = new System.Drawing.Point(168, 36);
            this.sniffModeCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sniffModeCheckbox.Name = "sniffModeCheckbox";
            this.sniffModeCheckbox.Size = new System.Drawing.Size(75, 17);
            this.sniffModeCheckbox.TabIndex = 9;
            this.sniffModeCheckbox.Text = "Winpcap?";
            this.sniffModeCheckbox.UseVisualStyleBackColor = true;
            this.sniffModeCheckbox.CheckedChanged += new System.EventHandler(this.sniffModeCheckbox_CheckedChanged);
            // 
            // regionSelector
            // 
            this.regionSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regionSelector.Enabled = false;
            this.regionSelector.FormattingEnabled = true;
            this.regionSelector.Location = new System.Drawing.Point(115, 58);
            this.regionSelector.Name = "regionSelector";
            this.regionSelector.Size = new System.Drawing.Size(121, 21);
            this.regionSelector.TabIndex = 12;
            this.regionSelector.SelectedIndexChanged += new System.EventHandler(this.regionSelector_SelectedIndexChanged);
            // 
            // autoUpload
            // 
            this.autoUpload.AutoSize = true;
            this.autoUpload.Location = new System.Drawing.Point(11, 60);
            this.autoUpload.Name = "autoUpload";
            this.autoUpload.Size = new System.Drawing.Size(60, 17);
            this.autoUpload.TabIndex = 13;
            this.autoUpload.Text = "Upload";
            this.autoUpload.UseVisualStyleBackColor = true;
            // 
            // displayName
            // 
            this.displayName.AutoSize = true;
            this.displayName.Checked = true;
            this.displayName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayName.Location = new System.Drawing.Point(11, 90);
            this.displayName.Name = "displayName";
            this.displayName.Size = new System.Drawing.Size(59, 17);
            this.displayName.TabIndex = 14;
            this.displayName.Text = "Names";
            this.displayName.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 123);
            this.Controls.Add(this.displayName);
            this.Controls.Add(this.autoUpload);
            this.Controls.Add(this.regionSelector);
            this.Controls.Add(this.checkUpdate);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.debugLog);
            this.Controls.Add(this.sniffModeCheckbox);
            this.Controls.Add(this.overlayEnabled);
            this.Controls.Add(this.weblink);
            this.Controls.Add(this.loggedPacketCountLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Lost Ark Logger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label loggedPacketCountLabel;
        private System.Windows.Forms.LinkLabel weblink;
        private System.Windows.Forms.CheckBox overlayEnabled;
        private System.Windows.Forms.CheckBox debugLog;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Button checkUpdate;
        private System.Windows.Forms.CheckBox sniffModeCheckbox;
        private System.Windows.Forms.ComboBox regionSelector;
        private System.Windows.Forms.CheckBox autoUpload;
        private System.Windows.Forms.CheckBox displayName;
    }
}
