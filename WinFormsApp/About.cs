using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void sourceLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.sourceLink.LinkVisited = true;

            var url = "https://github.com/olegpro171/MD2";
            Process.Start(new ProcessStartInfo() { FileName = url, UseShellExecute = true });
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
