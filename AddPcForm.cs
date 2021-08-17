﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wake_on_LAN.Net
{
    public partial class AddPcForm : Form
    {
        private MainForm _mainForm;
        public AddPcForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void AddPcForm_Load(object sender, EventArgs e)
        {

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            object[] row = { textBoxName.Text, textBoxMac.Text, textBoxNote.Text };
            _mainForm.AddRow(row);
            _mainForm.Show();
            this.Close();
        }
    }
}
