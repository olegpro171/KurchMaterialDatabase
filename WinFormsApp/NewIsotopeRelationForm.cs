using Backend.Domain;
using Backend.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class NewIsotopeRelationForm : Form
    {
        private bool densityValid;
        public float Density;
        public NewIsotopeRelationForm()
        {
            InitializeComponent();
        }
        private void NewIsotopeRelationForm_Load(object sender, EventArgs e)
        {
            densErrorLabel.Text = string.Empty;
        }

        public NewIsotopeRelationForm(ObjectWrapper<Fuel> fuel, RelatedObjectWrapper<Isotope> isotope)
        {
            InitializeComponent();

            materialIdTextBox.Text = fuel.Id.ToString();
            materialIdTextBox.Enabled = false;

            materialNameTextBox.Text = fuel.Obj.Name;
            materialNameTextBox.Enabled = false;

            isotopeBox.Text = isotope.Obj.Name;
            isotopeBox.Enabled = false;

            densityBox.Text = isotope.Concentration.ToString();
            densityValid = true;

            addButton.Text = "Сохранить";
        }

        private void densityBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Density = float.Parse(densityBox.Text);
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

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!densityValid)
            {
                SystemSounds.Beep.Play();
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
