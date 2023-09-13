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

namespace WinFormsApp
{
    public partial class IsotopeDisplayForm : Form
    {
        private ObjectWrapper<Isotope>? uneditedItemWrapper;
        private Isotope item;

        public Isotope Item { get { return item; } set { item = value; } }

        public IsotopeDisplayForm()
        {
            InitializeComponent();
            item = new Isotope();

            idTextBox.Text = "-авто-";
            idTextBox.Enabled = false;
            nameTextBox.Focus();

            deleteButton.Enabled = false;
            deleteButton.Visible = false;
        }

        public IsotopeDisplayForm(ObjectWrapper<Isotope> isotope)
        {
            InitializeComponent();
            uneditedItemWrapper = isotope;
            item = isotope.Obj;
        }

        private void IsotopeDisplayForm_Load(object sender, EventArgs e)
        {

            statusStrip.Text = string.Empty;
        }
    }
}
