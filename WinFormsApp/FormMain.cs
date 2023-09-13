using Backend.Core;
using Backend.Managers;

namespace WinFormsApp
{
    public partial class FormMain : Form
    {
        public static ConnectionData? ConnectionData { get; set; }

        private DatabaseCore Database;
        private FuelManager FuelManager;
        private IsotopeManager IsotopeManager;
        private IsotopeInFuelManager IsotopeInFuelManager;

        public FormMain()
        {
            InitializeComponent();
            Database = new DatabaseCore();
            FuelManager = new FuelManager(Database);
            IsotopeManager = new IsotopeManager(Database);
            IsotopeInFuelManager = new IsotopeInFuelManager(Database);
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
                Database.ConnectionData = ConnectionData;
                FuelManager.List();
            }
        }

        private void UpdateDataGrid()
        {
            dataGridView.DataSource = Database.ResponceTable;
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
            UpdateDataGrid();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            { return; }

            var id = (int)dataGridView.Rows[e.RowIndex].Cells[0].Value;

            var queryset = FuelManager.Get(id);
            var detailWin = new FuelDisplayForm(queryset);

            var dialogResult = detailWin.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                FuelManager.Update(id, detailWin.Item);
            }
        }

        private void nameSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            FuelManager.Filter("name", nameSearchTextBox.Text);
            UpdateDataGrid();
        }
    }
}