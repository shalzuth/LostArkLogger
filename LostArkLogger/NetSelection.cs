using System;
using System.Windows.Forms;

namespace LostArkLogger
{
    public partial class NetSelection : Form
    {
        public NetSelection()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_npcap_Click(object sender, EventArgs e)
        {
            this.Hide();

            var mainwindow = new MainWindow();
            mainwindow.Closed += (s, args) => this.Close();

            mainwindow.InitNpcap();
            mainwindow.Show();
        }

        private void btn_netsh_Click(object sender, EventArgs e)
        {
            this.Hide();

            var mainwindow = new MainWindow();
            mainwindow.Closed += (s, args) => this.Close();

            mainwindow.InitNetsh();
            mainwindow.Show();
        }
    }
}
