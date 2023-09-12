using Backend.Core;

namespace WinFormsApp
{
    public partial class FormMain : Form
    {
        public static ConnectionData? ConnectionData { get; set; }

        public FormMain()
        {
            InitializeComponent();
        }

        private void SetStatusTextConnectionData()
        {
            if (ConnectionData == null)
            {
                toolStripStatusLabel1.Text = "Не указаны данные для подключения";
            }
            else
            {
                toolStripStatusLabel1.Text = String.Empty;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SetStatusTextConnectionData();
        }

        private void connectionDataMenuItem_Click(object sender, EventArgs e)
        {
            var cdWin = new ConnectionDataWindow() { Owner = this };
            cdWin.ShowDialog();
            SetStatusTextConnectionData();
        }
    }
}