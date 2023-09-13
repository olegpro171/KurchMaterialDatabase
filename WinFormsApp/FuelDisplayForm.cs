using Backend.Domain;
using Backend.Managers;

namespace WinFormsApp
{
    public partial class FuelDisplayForm : Form
    {
        private ObjectWrapper<Fuel>? uneditedItemWrapper;
        private Fuel item;
        private bool isEditing;

        public Fuel Item
        {
            get { return item; }
        }
        public int? Id
        {
            get
            {
                if (isEditing && uneditedItemWrapper != null)
                    return uneditedItemWrapper.Id;
                else
                    return null;
            }
        }

        public FuelDisplayForm()
        {
            InitializeComponent();

            isEditing = false;

            item = new Fuel();
        }

        public FuelDisplayForm(Queryset<Fuel> queryset)
        {
            InitializeComponent();
            uneditedItemWrapper = queryset.Data.FirstOrDefault();
            if (uneditedItemWrapper != null)
            {
                item = uneditedItemWrapper.Obj;
            }

            SetValues();
            isEditing = true;
        }

        private void SetValues()
        {
            if (uneditedItemWrapper != null)
            {
                idTextBox.Text = uneditedItemWrapper.Id.ToString();
                nameTextBox.Text = item.Name;
                descTextBox.Text = item.Description;
                densTextBox.Text = item.Density.ToString();
            }
            else
            {
                idTextBox.Text = String.Empty;
                nameTextBox.Text = String.Empty;
                descTextBox.Text = String.Empty;
                densTextBox.Text = String.Empty;
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
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException
                    || ex is FormatException
                    || ex is OverflowException)
                {
                    densErrorLabel.ForeColor = Color.Red;
                    densErrorLabel.Text = "Введите корректное значение";
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

            DialogResult = DialogResult.OK;
            Close();
        }

        private void isoChangeButton_Click(object sender, EventArgs e)
        {
            // new window for isotopes
        }
    }
}
