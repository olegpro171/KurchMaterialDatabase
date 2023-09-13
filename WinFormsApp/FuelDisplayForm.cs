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



        public Fuel Item
        {
            get { return item; }
        }
        public int? Id
        {
            get
            {
                if (isEditingObject && uneditedItemWrapper != null)
                    return uneditedItemWrapper.Id;
                else
                    return null;
            }
        }

        public FuelDisplayForm()
        {
            InitializeComponent();

            isEditingObject = false;

            item = new Fuel();
            densityValid = false;

            idTextBox.Text = "-авто-";
            idTextBox.Enabled = false;
            nameTextBox.Focus();

            deleteButton.Enabled = false;
            deleteButton.Visible = false;
        }

        public FuelDisplayForm(Queryset<Fuel> fuelObjectQueryset, Queryset<Isotope> relatedIsotopes)
        {
            InitializeComponent();
            this.relatedIsotopes = relatedIsotopes;
            uneditedItemWrapper = fuelObjectQueryset.Data.FirstOrDefault();
            if (uneditedItemWrapper != null)
            {
                item = uneditedItemWrapper.Obj;
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
            if (uneditedItemWrapper != null)
            {
                idTextBox.Text = uneditedItemWrapper.Id.ToString();
                nameTextBox.Text = item.Name;
                descTextBox.Text = item.Description;
                densTextBox.Text = item.Density.ToString();
                colorTextBox.Text = item.Color;
            }
            else
            {
                idTextBox.Text = String.Empty;
                nameTextBox.Text = String.Empty;
                descTextBox.Text = String.Empty;
                densTextBox.Text = String.Empty;
                colorTextBox.Text = String.Empty;
            }

            if (isEditingObject && this.relatedIsotopes != null)
            {
                var isoTable = new DataTable("Related isotopes");

                isoTable.Columns.Add(new DataColumn("id", typeof(int)));
                isoTable.Columns.Add(new DataColumn("name", typeof(string)));
                isoTable.Columns.Add(new DataColumn("concentration", typeof(float)));

                isoTable.Columns[0].Caption = "Номер изотопа";
                (isoTable.Columns["name"] ?? throw new Exception("Undefined behavior")).Caption = "Название изотопа";
                (isoTable.Columns["concentration"] ?? throw new Exception("Undefined behavior")).Caption = "Содержание";

                foreach (RelatedObjectWrapper<Isotope> iso in relatedIsotopes.Data)
                {
                    var row = isoTable.NewRow();
                    row["id"] = iso.Id;
                    row["name"] = iso.Obj.Name;
                    row["concentration"] = iso.Concentration;
                    isoTable.Rows.Add(row);
                }

                isoGrid.DataSource = isoTable.Copy();
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

            if (ValidateFields())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                statusLabel.Text = "Заполните все поля";
                SystemSounds.Beep.Play();
            }
        }


        private void isoChangeButton_Click(object sender, EventArgs e)
        {
            // new window for isotopes
            var newIsoDialog = new NewIsotopeRelationForm();
            
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
            if (!isEditingObject || uneditedItemWrapper == null)
            {
                return;
            }

            var messageBoxResponce = MessageBox.Show(
                caption: "Удаление материала",
                text: $"Материал {uneditedItemWrapper.Obj.Name}, id = {uneditedItemWrapper.Id} " +
                       "будет удален из базы данных.\n\nВы уверены?",
                buttons: MessageBoxButtons.OKCancel,
                icon: MessageBoxIcon.Warning
                );
            if (messageBoxResponce == DialogResult.OK)
            {
                DialogResult = DialogResult.No; //Used as delete signal
                Close();
            }
        }

        private void isoGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }

            if (relatedIsotopes == null) { return; }
            if (!isEditingObject || uneditedItemWrapper == null) { return; }

            try
            {
                var isoSelected = (RelatedObjectWrapper<Isotope>)relatedIsotopes.Data[e.RowIndex];
                var editForm = new NewIsotopeRelationForm(uneditedItemWrapper, isoSelected);
                
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    var result = editForm.Density;
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                return;
            }
        }
    }
}
