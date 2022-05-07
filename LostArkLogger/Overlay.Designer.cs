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
            this.targetComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // targetComboBox
            // 
            this.targetComboBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.targetComboBox.DropDownHeight = 75;
            this.targetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.targetComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetComboBox.ForeColor = System.Drawing.Color.White;
            this.targetComboBox.FormattingEnabled = true;
            this.targetComboBox.IntegralHeight = false;
            this.targetComboBox.Items.AddRange(new object[] {
            "Total damages"});
            this.targetComboBox.Location = new System.Drawing.Point(77, 0);
            this.targetComboBox.Name = "targetComboBox";
            this.targetComboBox.Size = new System.Drawing.Size(121, 23);
            this.targetComboBox.TabIndex = 0;
            this.targetComboBox.SelectedIndexChanged += new System.EventHandler(this.TargetIndexChanged);
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

        private System.Windows.Forms.ComboBox targetComboBox;
    }
}