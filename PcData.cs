using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wake_on_LAN.Net
{
    class PcData
    {
        public string name;
        public string mac;
        public byte[] MacBytes;

        public PcData(string name, string mac, byte[] MacBytes)
        {
            this.name = name;
            this.mac = mac;
            this.MacBytes = MacBytes;
        }
    }
}
