using System;
using System.Windows.Forms;

namespace Wake_on_LAN.Net
{
    public partial class AddPcForm : Form
    {
        private readonly MainForm _mainForm;

        public AddPcForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void AddPcForm_Load(object sender, EventArgs e)
        {
        }

        private void Button_add_Click(object sender, EventArgs e)
        {
            object[] row = { textBoxName.Text, textBoxMac.Text, textBoxNote.Text };
            _mainForm.AddRow(row);
            _mainForm.Show();
            Close();
        }
    }
}