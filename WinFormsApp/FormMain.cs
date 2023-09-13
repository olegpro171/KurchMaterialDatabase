using Backend.Core;
using Backend.Exceptions;
using Backend.Managers;

namespace WinFormsApp
{
    public partial class FormMain : Form
    {
        private bool _isConnected;
        private bool isConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                _isConnected = value;
                if (value)
                {
                    materialsToolStripMenuItem.Enabled = true;
                }
                else
                {
                    materialsToolStripMenuItem.Enabled = false;
                }
            }
        }


        private Table _selectedTable;
        private Table SelectedTable
        {
            get { return _selectedTable; }
            set
            {
                _selectedTable = value;
                UpdateDataGrid();
            }
        }




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
            isConnected = false;
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
                isConnected = true;
                tableSelectBox.SelectedIndex = 0;
                tableSelectBox.Enabled = true;
            }
            catch (Npgsql.PostgresException ex)
            {
                if (ex.Message.StartsWith("28P01:"))
                {
                    toolStripStatusLabel1.Text = "Ошибка подключения: неверно указаны данные пользователя (логин или пароль)";
                }

                if (ex.Message.StartsWith("3D000:"))
                {
                    toolStripStatusLabel1.Text = "Ошибка подключения: указанная база данных не существует";
                }
                isConnected = false;
            }
            catch (System.Net.Sockets.SocketException)
            {
                toolStripStatusLabel1.Text = "Ошибка подключения: неверно хост";
                isConnected = false;
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
            }
        }

        private void UpdateDataGrid()
        {
            switch (SelectedTable)
            {
                case Table.FuelMaterials:
                    try
                    {
                        FuelManager.Filter("name", _searchstring);
                    }
                    catch (Npgsql.PostgresException ex)
                    {
                        if (ex.Message.StartsWith("42P01:"))
                        {
                            toolStripStatusLabel1.Text = "Отсутствуют необходимые таблицы";
                        }
                    }
                    dataGridView.DataSource = Database.ResponceTable;
                    break;

                case Table.Isotopes:
                    try
                    {
                        IsotopeManager.Filter("name", _searchstring);
                    }
                    catch (Npgsql.PostgresException ex)
                    {
                        if (ex.Message.StartsWith("42P01:"))
                        {
                            toolStripStatusLabel1.Text = "Отсутствуют необходимые таблицы";
                        }
                    }
                    dataGridView.DataSource = Database.ResponceTable;
                    break;


                default:
                    toolStripStatusLabel1.Text = "Неизвестная таблица";
                    dataGridView.DataSource = null;
                    break;
            }
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
                CheckOrCreateTables();
                UpdateDataGrid();

                // Throw exception if relation does not exist
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }

            if (SelectedTable != Table.FuelMaterials) { return; }
            
            
            var id = (int)dataGridView.Rows[e.RowIndex].Cells[0].Value;

            try
            {
                var isotopes = FuelManager.RelatedIsotopes(id);
                var fuel = FuelManager.Get(id);
                var detailWin = new FuelDisplayForm(fuel, isotopes);

                var dialogResult = detailWin.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    FuelManager.Update(id, detailWin.Item);
                }
                else if (dialogResult == DialogResult.No)
                {
                    FuelManager.Delete(id);
                }
                UpdateDataGrid();

            }
            catch (RecordNotFoundException ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
                return;
            }
        }

        private void nameSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchString = nameSearchTextBox.Text;
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var detailWin = new FuelDisplayForm();

            if (detailWin.ShowDialog() == DialogResult.OK)
            {
                FuelManager.Create(detailWin.Item);
                UpdateDataGrid();
            }
        }

        private void tableSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tableSelectBox.SelectedIndex == 0)
            {
                SelectedTable = Table.FuelMaterials;
            }
            else if (tableSelectBox.SelectedIndex == 1)
            {
                SelectedTable = Table.Isotopes;
            }
        }
    }


    internal enum Table
    {
        FuelMaterials = 0,
        Isotopes = 1,
    }
}