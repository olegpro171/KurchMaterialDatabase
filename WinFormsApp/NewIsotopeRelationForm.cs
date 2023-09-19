using Backend.Domain;
using Backend.Exceptions;
using Backend.Managers;
using System.Media;

namespace WinFormsApp
{
    public partial class NewIsotopeRelationForm : Form
    {
        private ObjectWrapper<IsotopeInFuel>? item;
        private ObjectWrapper<Fuel> fuel;
        private ObjectWrapper<Isotope>? iso;

        private Queryset<Isotope> allIsotopes;

        private readonly int? idEditing;

        private bool densityValid;
        public float Density;

        public NewIsotopeRelationForm(int fuelId, bool creatingNew = true)
        {
            InitializeComponent();

            deleteButton.Enabled = false;
            deleteButton.Visible = false;
            addButton.Text = "Добавить";
            idEditing = null;
            densityValid = false;

            fuel = dbConnector.FuelManager.Get(fuelId).Data.FirstOrDefault() ??
                throw new Exception("Invalid ID");

            allIsotopes = dbConnector.IsotopeManager.List();
            SetInitialValuesCreate();

        }

        public NewIsotopeRelationForm(int relation_id)
        {
            InitializeComponent();

            allIsotopes = dbConnector.IsotopeManager.List();

            deleteButton.Enabled = true;
            deleteButton.Visible = true;
            addButton.Text = "Сохранить";

            idEditing = relation_id;

            try
            {
                item = dbConnector.IsotopeInFuelManager.Get(relation_id).Data.FirstOrDefault();
                if (item == null)
                    throw new RecordNotFoundException();
            }
            catch (RecordNotFoundException)
            {
                MessageBox.Show(
                            caption: "Редактируемое отношение не найдено",
                            text: "Редактируемое отношение не найдено",
                            icon: MessageBoxIcon.Error,
                            buttons: MessageBoxButtons.OK
                            );
                Load += (s, e) => Close();
                return;
            }

            integrityCheck(); // will set iso and fuel fields
            if (fuel == null || iso == null) { throw new Exception("Undefined behavior"); }

            SetInitialValues();
        }

        private void NewIsotopeRelationForm_Load(object sender, EventArgs e)
        {
            densErrorLabel.Text = string.Empty;
        }

        private void SetInitialValuesCreate()
        {
            if (fuel == null)
                return;

            materialIdTextBox.Text = fuel.Id.ToString();
            materialIdTextBox.Enabled = false;

            materialNameTextBox.Text = fuel.Obj.Name;
            materialNameTextBox.Enabled = false;

            isotopeBox.Enabled = true;

            isotopeBox.Items.Clear();


            foreach (var item in allIsotopes.Data)
            {
                isotopeBox.Items.Add(item.Obj.Name);
            }
        }

        private void SetInitialValues()
        {
            if (idEditing == null
                || fuel == null
                || iso == null
                || item == null)
            {
                return;
            }


            materialIdTextBox.Text = fuel.Id.ToString();
            materialIdTextBox.Enabled = false;

            materialNameTextBox.Text = fuel.Obj.Name;
            materialNameTextBox.Enabled = false;

            isotopeBox.Text = iso.Obj.Name;
            isotopeBox.Enabled = false;

            densityBox.Text = item.Obj.Amount.ToString();
            densityValid = true;

        }

        private void integrityCheck()
        {
            if (idEditing == null || item == null)
            {
                return;
            }

            ObjectWrapper<Fuel>? fuel;
            ObjectWrapper<Isotope>? iso;

            try
            {
                fuel = dbConnector.FuelManager.Get(item.Obj.ID_2).Data.FirstOrDefault();
            }
            catch (RecordNotFoundException)
            {
                fuel = null;
            }

            try
            {
                iso = dbConnector.IsotopeManager.Get(item.Obj.ID_1).Data.FirstOrDefault();
            }
            catch (RecordNotFoundException)
            {
                iso = null;
            }

            if (fuel != null && iso != null)
            {
                this.fuel = fuel;
                this.iso = iso;
                return;
            }

            string errorMsg = $"Произошла ошибка при проверке целостности связи. Связь с внутренним id = {idEditing}" +
                $" ссылается на:\n\n";

            if (fuel == null)
            {
                errorMsg += $" - материал с id = {item.Obj.ID_2}, который отсутствует в базе данных\n\n";
            }

            if (iso == null)
            {
                errorMsg += $" - изотоп с id = {item.Obj.ID_2}, который отсутствует в базе данных\n\n";
            }

            errorMsg += "Нажмите \"ОК\" для удаления этой связи или \"Отмена\" для закрытия окна редактирования.";

            var dialogResult = MessageBox.Show(
                caption: "Нарушение целостности",
                text: errorMsg,
                icon: MessageBoxIcon.Error,
                buttons: MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK)
            {
                dbConnector.IsotopeInFuelManager.Delete((int)idEditing);
                Close();
                return;
            }

            if (dialogResult != DialogResult.Cancel)
            {
                Close();
                return;
            }
        }

        private void densityBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Density = float.Parse(densityBox.Text);
                densErrorLabel.Text = String.Empty;
                densityValid = true;
                densErrorLabel.Visible = false;
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException
                    || ex is FormatException
                    || ex is OverflowException)
                {
                    densErrorLabel.Text = "Введите корректное значение";
                    densErrorLabel.Visible = true;
                    densityValid = false;
                }
                else
                {
                    throw;
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!densityValid)
            {
                SystemSounds.Beep.Play();
                return;
            }

            if (isotopeBox.Enabled && isotopeBox.SelectedIndex == -1)
            {
                SystemSounds.Beep.Play();
                return;
            }

            if (idEditing != null && item != null)
            {
                item.Obj.Amount = Density;
                dbConnector.IsotopeInFuelManager.Update((int)idEditing, item.Obj);
                Close();
                return;
            }

            if (idEditing == null)
            {
                var selectedIsotopeID = allIsotopes.Data[isotopeBox.SelectedIndex].Id;

                var newIIF = new IsotopeInFuel(selectedIsotopeID, fuel.Id, Density);
                try
                {
                    dbConnector.IsotopeInFuelManager.Create(newIIF);
                    Close();
                }
                catch (DuplicateRelationException)
                {
                    MessageBox.Show(
                        caption: "Отношение уже существует",
                        text: $"Отношение изотопа {allIsotopes.Data[isotopeBox.SelectedIndex].Obj.Name} к материалу {fuel.Obj.Name} уже существует.",
                        icon: MessageBoxIcon.Error,
                        buttons: MessageBoxButtons.OK
                        );
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (idEditing == null || item == null || iso == null || fuel == null)
            {
                return;
            }

            var dialogResult = MessageBox.Show(
                text: $"Вы собираетесь удалить отношение изотопа {iso.Obj.Name} к материалу {fuel.Obj.Name}. " +
                $"Изменение бызв данных будет применено немедлено.\n\n" +
                $"Нажмите \"ОК\", чтобы продолжить.",
                caption: "Удаление отношения",
                icon: MessageBoxIcon.Asterisk,
                buttons: MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }
            if (dialogResult == DialogResult.OK)
            {
                dbConnector.IsotopeInFuelManager.Delete((int)idEditing);
                Close();
            }
        }

        private void isotopeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
