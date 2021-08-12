using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wake_on_LAN.Net
{
    public partial class MainForm : Form
    {
        private const string Path = @".\details.txt";
        private List<PcData> _pcData;
        private static byte[] _selectedMac;

        public MainForm()
        {
            InitializeComponent();
        }

        public static void AddRow(object[] row)
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
                    Console.WriteLine(line);
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
        }

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView.Rows[e.RowIndex].Selected = true;
                Console.WriteLine(dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
                _selectedMac = PcData.StrToMac(dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            foreach (var data in _pcData)
            {
                if (data.MacBytes.SequenceEqual(_selectedMac))
                {
                    PcData.WakeUp(_selectedMac);
                    MessageBox.Show(
                        $@"Вы только что отправили запрос на включение компьютера ""{data.Name} | {data.Note}""");
                }
            }
        }

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            Form form = new AddPcForm();
            form.Show();
        }
    }
}