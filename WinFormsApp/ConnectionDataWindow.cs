using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Backend.Core;

namespace WinFormsApp
{
    public partial class ConnectionDataWindow : Form
    {


        public ConnectionDataWindow()
        {
            InitializeComponent();
        }

        private bool checkFields()
        {
            if (this.hostTextBox.Text.Length > 0
                && this.databaseTextBox.Text.Length > 0
                && this.usernameTextBox.Text.Length > 0
                && this.passwordTextBox.Text.Length > 0)
            {
                return true;
            }
            return false;
        }

        private void databaseTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void hostTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordTextChanged(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                
                FormMain.ConnectionData = new ConnectionData(
                    hostTextBox.Text,
                    usernameTextBox.Text,
                    passwordTextBox.Text,
                    databaseTextBox.Text
                    );
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "Заполните все поля";
                SystemSounds.Beep.Play();
            }
        }

        private void ConnectionDataWindow_Load(object sender, EventArgs e)
        {

        }

        private void ConnectionDataWindow_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
