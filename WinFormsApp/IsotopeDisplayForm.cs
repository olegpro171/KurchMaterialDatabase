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
        private ObjectWrapper<Isotope>? item;

        private readonly int? idEditing;


        public IsotopeDisplayForm()
        {
            InitializeComponent();
            //item = new Isotope();

            idTextBox.Text = "-авто-";
            idTextBox.Enabled = false;
            nameTextBox.Focus();

            deleteButton.Enabled = false;
            deleteButton.Visible = false;
        }

        public IsotopeDisplayForm(int id)
        {
            InitializeComponent();
            idEditing = id;

            try
            {
                item = dbConnector.IsotopeManager.Get(id).Data.FirstOrDefault();
                if (item == null)
                    throw new RecordNotFoundException();
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

        
        // TODO: Написать функцию для валидации изотопа (Уникальное имя)
        // TODO: Написать функцию предупреждения о каскадном изменении

        private void SetInitialData()
        {
            // TODO: Написать инициализацию полей при редактировании изотопа
        }

        private void IsotopeDisplayForm_Load(object sender, EventArgs e)
        {

            statusStrip.Text = string.Empty;
        }
    }
}
