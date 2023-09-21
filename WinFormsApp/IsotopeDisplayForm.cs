using Backend.Managers;
using Backend.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backend.Exceptions;

namespace WinFormsApp
{
    public partial class IsotopeDisplayForm : Form
    {
        private Isotope item;
        private Queryset<Fuel> cascade;

        private bool isNameValid;

        private readonly int? idEditing;
        private readonly string originalName;


        public IsotopeDisplayForm()
        {
            InitializeComponent();
            item = new Isotope();

            idTextBox.Text = "-авто-";
            idTextBox.Enabled = false;

            deleteButton.Enabled = false;
            deleteButton.Visible = false;

            isNameValid = false;

            originalName = string.Empty;

            cascade = new Queryset<Fuel>();
            cascadeGridView.Visible = false;

            emptyCascadeLabel.Visible = true;
            emptyCascadeLabel.Text = "Связанные материалы отображаются после создания";

            cascadeLabel.Visible = false;
        }

#pragma warning disable CS8618 
        public IsotopeDisplayForm(int id)
#pragma warning restore CS8618
        {
            InitializeComponent();
            idEditing = id;
            idTextBox.Text = id.ToString();
            idTextBox.Enabled = false;

            isNameValid = true;

            cascade = dbConnector.IsotopeManager.RelatedMaterials((int)idEditing);

            if (cascade.Data.Count == 0)
            {
                cascadeLabel.Visible = false;
                cascadeGridView.Visible = false;
                emptyCascadeLabel.Visible = true;
            }
            else
            {
                cascadeLabel.Visible = true;
                cascadeGridView.Visible = true;
                emptyCascadeLabel.Visible = false;
            }
            try
            {
                var wrapper = dbConnector.IsotopeManager.Get(id).Data.FirstOrDefault();
                if (wrapper == null)
                    throw new RecordNotFoundException();

                item = wrapper.Obj;
                originalName = item.Name;

            }
            catch (RecordNotFoundException)
            {
                MessageBox.Show(
                            caption: "Редактируемый изотоп не найден",
                            text: "Редактируемый изотоп не найден",
                            icon: MessageBoxIcon.Error,
                            buttons: MessageBoxButtons.OK
                            );
                Load += (s, e) => Close(); // Добавление дополнительного обработчика, который закроет форму сразу после загрузки
                                           // если редактируемая запись не найдена
                return;
            }
            SetInitialData();
        }


        private bool ValidateUnuqueName(string name)
        {
            if (item.Name == String.Empty) return false;

            var allIsotopes = dbConnector.IsotopeManager.Filter("name", name, exact: true);
            var count = allIsotopes.Data.Count;


            if (count > 1) return false;

            if (count == 1)
            {
                var singleItem = allIsotopes.Data[0];
                if (singleItem.Id == idEditing) return true;
                else return false;
            }

            if (count == 0) return true;

            return false; // Недостижимая ветвь
        }

        private void SetInitialData()
        {
            nameTextBox.Text = item.Name;

            if (idEditing != null)
            {
                cascadeGridView.DataSource = dbConnector.GetRelatedMaterialsTable((int)idEditing);
                cascadeGridView.Columns[0].HeaderText = "Материал";
                cascadeGridView.Columns[1].HeaderText = "% содерж.";

            }
        }

        private void IsotopeDisplayForm_Load(object sender, EventArgs e)
        {
            statusLabel.Text = string.Empty;
            nameTextBox.Focus();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            var name = nameTextBox.Text;
            isNameValid = false;

            if (nameTextBox.Text == String.Empty)
            {
                statusLabel.Text = "Укажите имя изотопа";
                return;
            }

            if (!ValidateUnuqueName(name))
            {
                statusLabel.Text = "Имя изотопа должно быть уникальным";
                return;
            }

            statusLabel.Text = string.Empty;
            item.Name = name;
            isNameValid = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (idEditing != null && isNameValid)
            {
                if (cascadeGridView.Rows.Count > 0)
                {
                    var messageBoxResponce = MessageBox.Show(
                        text: $"Вы собираетесь изменить имя изотопа {originalName}. " +
                        $"Изменение затронет связанные материлы. Количество: {cascadeGridView.Rows.Count}.\n\n" +
                        $"Нажмите \"ОК\", чтобы продолжить.",
                        caption: "Каскадное изменение",
                        icon: MessageBoxIcon.Asterisk,
                        buttons: MessageBoxButtons.OKCancel
                        );

                    if (messageBoxResponce == DialogResult.OK)
                    {
                        dbConnector.IsotopeManager.Update((int)idEditing, item);
                        Close();
                        return;
                    }
                    else return;

                }

                dbConnector.IsotopeManager.Update((int)idEditing, item);
                Close();
                return;
            }


            if (idEditing == null && isNameValid)
            {
                dbConnector.IsotopeManager.Create(item);
                Close();
                return;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (idEditing == null) return;


            if (cascadeGridView.Rows.Count > 0)
            {
                var messageBoxResponce = MessageBox.Show(
                    text: $"Вы собираетесь удалить изотоп {originalName}. " +
                    $"Будет произведено каскадное удаление связанных материлов. Количество: {cascadeGridView.Rows.Count}.\n\n" +
                    $"Нажмите \"ОК\", чтобы продолжить.",
                    caption: "Каскадное удаление",
                    icon: MessageBoxIcon.Asterisk,
                    buttons: MessageBoxButtons.OKCancel
                    );

                if (messageBoxResponce == DialogResult.OK)
                {
                    dbConnector.IsotopeManager.Delete((int)idEditing);
                    Close();
                    return;
                }
                else return;
            }

            if (cascadeGridView.Rows.Count == 0)
            {
                var messageBoxResponce = MessageBox.Show(
                    text: $"Вы собираетесь удалить изотоп {originalName}. " +
                    $"Изотоп не имеет связанных материлов.\n\n" +
                    $"Нажмите \"ОК\", чтобы продолжить.",
                    caption: "Удаление изотопа",
                    icon: MessageBoxIcon.Asterisk,
                    buttons: MessageBoxButtons.OKCancel
                    );

                if (messageBoxResponce == DialogResult.OK)
                {
                    dbConnector.IsotopeManager.Delete((int)idEditing);
                    Close();
                    return;
                }
                else return;
            }
        }
    }
}
