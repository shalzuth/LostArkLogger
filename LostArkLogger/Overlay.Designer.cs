namespace LostArkLogger
{
    partial class Overlay
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
            this.targetComboBox = new LostArkLogger.LoggerComboBox();
            this.SuspendLayout();
            // 
            // targetComboBox
            // 
            this.targetComboBox.BackColor = System.Drawing.Color.Transparent;
            this.targetComboBox.BorderColor = System.Drawing.Color.Black;
            this.targetComboBox.BorderSize = 0;
            this.targetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.targetComboBox.Font = new System.Drawing.Font("MS Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetComboBox.ForeColor = System.Drawing.Color.DimGray;
            this.targetComboBox.IconColor = System.Drawing.Color.White;
            this.targetComboBox.ListBackColor = System.Drawing.Color.Black;
            this.targetComboBox.ListTextColor = System.Drawing.Color.White;
            this.targetComboBox.Location = new System.Drawing.Point(58, 0);
            this.targetComboBox.MinimumSize = new System.Drawing.Size(200, 30);
            this.targetComboBox.Name = "targetComboBox";
            this.targetComboBox.Size = new System.Drawing.Size(200, 30);
            this.targetComboBox.TabIndex = 0;
            this.targetComboBox.Texts = "";
            this.targetComboBox.OnSelectedIndexChanged += new System.EventHandler(this.targetComboBox_OnSelectedIndexChanged);
            // 
            // Overlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 120);
            this.Controls.Add(this.targetComboBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "Overlay";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Overlay";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Overlay_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private LoggerComboBox targetComboBox;
    }
}