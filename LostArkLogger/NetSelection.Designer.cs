namespace LostArkLogger
{
    partial class NetSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetSelection));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_npcap = new System.Windows.Forms.Button();
            this.btn_netsh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Packet Analyzer Method";
            // 
            // btn_npcap
            // 
            this.btn_npcap.Location = new System.Drawing.Point(12, 33);
            this.btn_npcap.Name = "btn_npcap";
            this.btn_npcap.Size = new System.Drawing.Size(100, 30);
            this.btn_npcap.TabIndex = 1;
            this.btn_npcap.Text = "NPcap";
            this.btn_npcap.UseVisualStyleBackColor = true;
            this.btn_npcap.Click += new System.EventHandler(this.btn_npcap_Click);
            // 
            // btn_netsh
            // 
            this.btn_netsh.Location = new System.Drawing.Point(118, 33);
            this.btn_netsh.Name = "btn_netsh";
            this.btn_netsh.Size = new System.Drawing.Size(100, 30);
            this.btn_netsh.TabIndex = 1;
            this.btn_netsh.Text = "NetSh (Firewall)";
            this.btn_netsh.UseVisualStyleBackColor = true;
            this.btn_netsh.Click += new System.EventHandler(this.btn_netsh_Click);
            // 
            // NetSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 79);
            this.Controls.Add(this.btn_netsh);
            this.Controls.Add(this.btn_npcap);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NetSelection";
            this.Text = "Lost Ark Logger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_npcap;
        private System.Windows.Forms.Button btn_netsh;
    }
}