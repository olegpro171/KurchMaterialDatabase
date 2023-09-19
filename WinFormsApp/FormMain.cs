using Backend.Core;
using Backend.Domain;
using Backend.Exceptions;
using Backend.Managers;
using Microsoft.Win32;
using WinFormsApp.Exceptions;


// TO DO: Запретить создание одинаковых отношений изотопов к материалам


namespace WinFormsApp
{
    public partial class FormMain : Form
    {

        private dbConnector.Table _selectedTable;
        private dbConnector.Table SelectedTable
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
                dbConnector.SearchString = value;
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


        private void SetStatusTextConnectionData()
        {
            if (dbConnector.LastOperationSuccesful == true)
            {
                toolStripStatusLabel1.Text = String.Empty;
            }
            else
            {
                toolStripStatusLabel1.Text = "Ошибка подключения";
            }
        }

        private void UpdateDataGrid()
        {
            try
            {
                dataGridView.DataSource = dbConnector.GetMainTable(SelectedTable);
                dataGridView.Columns["id"].Width = 50;
                dataGridView.Columns["name"].Width = 200;
                dataGridView.Columns["density"].Width = 75;
                dataGridView.Columns["name"].HeaderText = "Материал";
                dataGridView.Columns["description"].HeaderText = "Описание";
                dataGridView.Columns["density"].HeaderText = "Плотность";

            }

            catch (ArgumentException)
            {
                toolStripStatusLabel1.Text = "Неверно указана таблица";
                return;
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.StartsWith("O02:"))
                {
                    toolStripStatusLabel1.Text = "Не указаны данные для подключения";
                    return;
                }
                if (ex.Message.StartsWith("O01:"))
                {
                    dbConnector.CreateTablesIfNotExist();
                    toolStripStatusLabel1.Text = "Таблицы созданы, обновите отображение";
                }

            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Укажите данные для подключения";
            materialsToolStripMenuItem.Enabled = false;

            //var postgres = Registry.CurrentUser.OpenSubKey(@"Software\pgadmin");
            //if (postgres == null)
            //{

            //}
        }

        private void connectionDataMenuItem_Click(object sender, EventArgs e)
        {
            var cdWin = new ConnectionDataWindow() { Owner = this };

            if (cdWin.ShowDialog() == DialogResult.OK)
            {
                dbConnector.ConnectionData = cdWin.ConnectionData ?? throw new Exception("Undefined behavior");

                try
                {
                    dbConnector.CreateTablesIfNotExist();
                    if (dbConnector.LastOperationSuccesful)
                    {
                        materialsToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        materialsToolStripMenuItem.Enabled = false;
                    }
                }
                catch (InvalidConnectionDataException ex)
                {
                    if (ex.Message.StartsWith("CD1:"))
                    {
                        toolStripStatusLabel1.Text = "Ошибка подключения: неверно указаны данные пользователя (логин или пароль)";
                        return;
                    }

                    if (ex.Message.StartsWith("CD2:"))
                    {
                        toolStripStatusLabel1.Text = "Ошибка подключения: указанная база данных не существует";
                        return;
                    }

                    if (ex.Message.StartsWith("CD3:"))
                    {
                        toolStripStatusLabel1.Text = "Ошибка подключения: указанный хост недоступен";
                        return;
                    }
                }
                SetStatusTextConnectionData();
                UpdateDataGrid();

                tableSelectBox.Enabled = true;
                tableSelectBox.SelectedIndex = 0;

                // Throw exception if relation does not exist
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }

            if (SelectedTable != dbConnector.Table.FuelMaterials) { return; }


            var id = (int)dataGridView.Rows[e.RowIndex].Cells["id"].Value;

            try
            {
                var detailWin = new FuelDisplayForm(id);
                detailWin.ShowDialog();
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
            detailWin.ShowDialog();
            UpdateDataGrid();
        }

        private void tableSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tableSelectBox.SelectedIndex == 0)
            {
                SelectedTable = dbConnector.Table.FuelMaterials;
            }
            else if (tableSelectBox.SelectedIndex == 1)
            {
                SelectedTable = dbConnector.Table.Isotopes;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutWin = new About();

            aboutWin.Show();
        }
    }
}