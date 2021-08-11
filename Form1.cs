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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string path = @".\details.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                List<PcData> pcData = new List<PcData>();
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    Console.WriteLine(line);
                    string[] data = GetData(line);
                    string name = data[0];
                    string mac = data[1];
                    Console.WriteLine(name + " | " + mac);
                    string[] row = {name, mac};
                    dataGridView1.Rows.Add(row);
                    pcData.Add(new PcData(name, mac, StrToMac(mac)));
                }
            }
        }

        public string[] GetData(string line)
        {
            string[] data = line.Split(';');
            data[0] = data[0].Replace("\"", "");
            data[1] = data[1].Replace("\"", "");
            return data;
        }

        static byte[] StrToMac(string s)
        {
            List<byte> arr = new List<byte>(102);

            string[] macs = s.Split(' ', ':', '-');

            for (int i = 0; i < 6; i++)
                arr.Add(0xff);

            for (int j = 0; j < 16; j++)
            for (int i = 0; i < 6; i++)
                arr.Add(Convert.ToByte(macs[i], 16));

            return arr.ToArray();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //dataGridView1.Rows[0].Selected = true; // переделать на выбранную строку, получая ее из аргумент 'e'
        }
    }
}
