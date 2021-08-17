using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wake_on_LAN.Net
{
    public partial class MainForm : Form
    {
        private const string Path = @".\details.txt";
        private static byte[] _selectedMac;
        private bool _editMode;
        private List<PcData> _pcData;

        public MainForm()
        {
            InitializeComponent();
            _editMode = false;
        }

        public void AddRow(object[] row)
        {
            if (row != null)
                dataGridView.Rows.Add(row);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            using (var sr = new StreamReader(Path, Encoding.Default))
            {
                string line;
                _pcData = new List<PcData>();
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    //Console.WriteLine(line);
                    var data = Data.GetData(line);
                    var name = data[0];
                    var mac = data[1];
                    var note = data[2];
                    //Console.WriteLine(name + " | " + mac);
                    object[] row = { name, mac, note };
                    dataGridView.Rows.Add(row);
                    _pcData.Add(new PcData(name, mac, PcData.StrToMac(mac), note));
                }

                if (dataGridView.CurrentRow != null)
                    _selectedMac = PcData.StrToMac(dataGridView.CurrentRow.Cells[1].Value.ToString());
            }

            var stop = false;
            foreach (var iData in _pcData)
            {
                if (stop)
                    break;
                if (_pcData.All(jData => iData.MacBytes != jData.MacBytes)) continue;
                MessageBox.Show(@"Внимание! Есть повторяющиеся MAC-адреса!");
                stop = true;
            }
        }

        private void DataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_editMode)
                return;

            if (e.RowIndex < 0)
                return;
            dataGridView.Rows[e.RowIndex].Selected = true;
            //Console.WriteLine(dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
            _selectedMac = PcData.StrToMac(dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
        }

        private void Button_Click(object sender, EventArgs e)
        {
            foreach (var data in _pcData)
                if (data.MacBytes.SequenceEqual(_selectedMac))
                {
                    PcData.WakeUp(_selectedMac);
                    MessageBox.Show(
                        $@"Вы только что отправили запрос на включение компьютера ""{data.Name} | {data.Note}""");
                    break;
                }
        }

        private void ButtonAddRow_Click(object sender, EventArgs e)
        {
            Form form = new AddPcForm(this);
            form.Show();
        }

        private void ButtonEditMode_Click(object sender, EventArgs e)
        {
            _editMode = !_editMode;
            //Console.WriteLine(buttonEditMode.BackColor.ToString());
            buttonEditMode.BackColor = _editMode ? Color.Brown : Color.Gainsboro;
            dataGridView.EditMode = _editMode
                ? DataGridViewEditMode.EditOnKeystrokeOrF2
                : DataGridViewEditMode.EditProgrammatically;
        }
    }
}