using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wake_on_LAN.Net
{
    internal class Data
    {
        public static string[] GetData(string line)
        {
            string[] data = line.Split(';');
            data[0] = data[0].Replace("\"", "");
            data[1] = data[1].Replace("\"", "");
            data[2] = data[2].Replace("\"", "");
            return data;
        }
    }
}
