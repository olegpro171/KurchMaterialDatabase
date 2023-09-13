using Backend.Core;
using Backend.Managers;

namespace WinFormsApp
{
    public partial class FormMain : Form
    {
        private string _searchstring;
        private string SearchString
        {
            set
            {
                _searchstring = value;
                UpdateDataGrid();
            }
        }
        private ConnectionData? connectionData;
        public ConnectionData ConnectionData
        {
            set
            {
                connectionData = value;
                Database.ConnectionData = value;
            }
        }

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
            _searchstring = String.Empty;
        }

        private void CheckOrCreateTables()
        {
            if (connectionData == null)
            {
                toolStripStatusLabel1.Text = "Не указаны данные для подключения";
                return;
            }

            try
            {
                IsotopeManager.CreateTable();
                FuelManager.CreateTable();
                IsotopeInFuelManager.CreateTable();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void SetStatusTextConnectionData()
        {
            if (connectionData == null)
            {
                toolStripStatusLabel1.Text = "Не указаны данные для подключения";
            }
            else
            {
                toolStripStatusLabel1.Text = String.Empty;
                CheckOrCreateTables();
                UpdateDataGrid();
            }
        }

        private void UpdateDataGrid()
        {
            try
            {
                FuelManager.Filter("name", _searchstring);
            }
            catch (Npgsql.PostgresException ex)
            {
                if (ex.Message.StartsWith("42P01:"))
                {
                    toolStripStatusLabel1.Text = "Ошибка";
                }
            }
            dataGridView.DataSource = Database.ResponceTable;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SetStatusTextConnectionData();
        }

        private void connectionDataMenuItem_Click(object sender, EventArgs e)
        {
            var cdWin = new ConnectionDataWindow() { Owner = this };
            var dialogResult = cdWin.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                ConnectionData = cdWin.ConnectionData ?? throw new Exception("Undefined behavior");
                SetStatusTextConnectionData();
                UpdateDataGrid();

                // Throw exception if relation does not exist
            }
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
                UpdateDataGrid();
            }
        }

        private void nameSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchString = nameSearchLabel.Text;
        }
    }
}