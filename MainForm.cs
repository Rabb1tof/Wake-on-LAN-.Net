using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wake_on_LAN.Net
{
    public partial class MainForm : Form
    {
        private List<PcData> _pcData;
        private const string Path = @".\details.txt";
        private byte[] _selectedMac;
        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            using (var sr = new StreamReader(Path, System.Text.Encoding.Default))
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
                    object[] row = {name, mac, note};
                    dataGridView.Rows.Add(row);
                    _pcData.Add(new PcData(name, mac, PcData.StrToMac(mac)));
                }
            }
        }
        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView.Rows[e.RowIndex].Selected = true;
            Console.WriteLine(dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
            _selectedMac = PcData.StrToMac(dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
        }

        private void button_Click(object sender, EventArgs e)
        {

                    PcData.WakeUp(_selectedMac);
                    MessageBox.Show("Вы только что отправили запрос на включение компьютера \"" +
                                    dataGridView.CurrentRow.Cells[0].Value.ToString() + " | " + dataGridView.CurrentRow.Cells[2].Value.ToString() + "\"");
        }
    }
}
