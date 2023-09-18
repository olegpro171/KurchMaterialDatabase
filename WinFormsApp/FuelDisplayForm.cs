using Backend.Domain;
using Backend.Managers;
using System.Data;
using System.Media;

namespace WinFormsApp
{
    public partial class FuelDisplayForm : Form
    {
        private Queryset<Isotope>? relatedIsotopes;
        private ObjectWrapper<Fuel>? uneditedItemWrapper;
        private Fuel item;
        private bool isEditingObject;
        private bool densityValid;

        private readonly string originalName;

        private int? idEditing;

        private DataTable? isoDataTable;

        public FuelDisplayForm()
        {
            InitializeComponent();

            isEditingObject = false;

            item = new Fuel();
            densityValid = false;
            originalName = "Новый материал";

            idTextBox.Text = "-авто-";
            idTextBox.Enabled = false;
            nameTextBox.Focus();

            deleteButton.Enabled = false;
            deleteButton.Visible = false;
        }

        public FuelDisplayForm(int idToEdit)
        {
            InitializeComponent();
            idEditing = idToEdit;
            var itemList = dbConnector.FuelManager.Get(idToEdit).Data.FirstOrDefault();
            if (itemList != null)
            {
                item = itemList.Obj;
                originalName = item.Name;
            }
            else
            {
                throw new Exception("Invalid object");
            }

            isEditingObject = true;
            densityValid = true;
            SetInitialValues();
        }

        private void FuelDisplayForm_Load(object sender, EventArgs e)
        {
            statusLabel.Text = string.Empty;
            densErrorLabel.Text = string.Empty;
        }

        private bool ValidateFields()
        {
            if (item.Name.Length < 1
                || item.Description.Length < 1
                || !densityValid
                || item.Color.Length < 1)
            {
                return false;
            }

            return true;
        }

        private void SetInitialValues()
        {
            if (idEditing != null)
            {
                idTextBox.Text = idEditing.ToString();
                nameTextBox.Text = item.Name;
                descTextBox.Text = item.Description;
                densTextBox.Text = item.Density.ToString();
                colorTextBox.Text = item.Color;
                SetTableValues();
            }
            else
            {
                idTextBox.Text = String.Empty;
                nameTextBox.Text = String.Empty;
                descTextBox.Text = String.Empty;
                densTextBox.Text = String.Empty;
                colorTextBox.Text = String.Empty;
            }
        }

        private void SetTableValues()
        {
            if (idEditing != null)
            {
                isoDataTable = dbConnector.GetRelatedIsotopesTable((int)idEditing);
                isoGrid.DataSource = isoDataTable;
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            item.Name = nameTextBox.Text;
        }

        private void densTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                item.Density = float.Parse(densTextBox.Text);
                densErrorLabel.Text = String.Empty;
                densityValid = true;
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException
                    || ex is FormatException
                    || ex is OverflowException)
                {
                    densErrorLabel.ForeColor = Color.Red;
                    densErrorLabel.Text = "Введите корректное значение";
                    densityValid = false;
                }
                else
                {
                    throw;
                }
            }
        }

        private void descTextBox_TextChanged(object sender, EventArgs e)
        {
            item.Description = descTextBox.Text;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            if (!ValidateFields())
            {
                statusLabel.Text = "Заполните все поля";
                SystemSounds.Beep.Play();
                return;
            }

            if (idEditing != null)
            {
                try
                {
                    dbConnector.FuelManager.Update((int)idEditing, item);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    dbConnector.FuelManager.Create(item);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void isoChangeButton_Click(object sender, EventArgs e)
        {
            if (idEditing == null)
            { return; }

            var newIsoDialog = new NewIsotopeRelationForm((int)idEditing, true);
            
            newIsoDialog.ShowDialog();
            SetTableValues();
        }

        private void colorSelectButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                item.Color = HexConverter(colorDialog1.Color);
                colorTextBox.Text = HexConverter(colorDialog1.Color);
            }
        }

        private static String HexConverter(Color c)
        {
            return $"#{c.R.ToString("X2")}{c.G.ToString("X2")}{c.B.ToString("X2")}";
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (idEditing == null)
            {
                return;
            }

            var messageBoxResponce = MessageBox.Show(
                caption: "Удаление материала",
                text: $"Материал {originalName}, id = {idEditing} " +
                       "будет удален из базы данных.\n\nВы уверены?",
                buttons: MessageBoxButtons.OKCancel,
                icon: MessageBoxIcon.Warning
                );
            if (messageBoxResponce == DialogResult.OK)
            {
                dbConnector.FuelManager.Delete((int)idEditing);
                Close();
            }
        }

        private void isoGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }

            if (isoDataTable == null)
            {
                return;
            }

            int relation_id = isoDataTable.Rows[e.RowIndex].Field<int>("relation_id");

            var isoRelationForm = new NewIsotopeRelationForm(relation_id);

            isoRelationForm.ShowDialog();
            SetTableValues();
        }
    }
}
