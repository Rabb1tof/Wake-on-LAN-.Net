using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Wake_on_LAN.Net
{
    internal class PcData
    {
        public string Mac;
        public byte[] MacBytes;
        public string Name;

        public PcData(string name, string mac, byte[] macBytes)
        {
            Name = name;
            Mac = mac;
            MacBytes = macBytes;
        }

        public static byte[] StrToMac(string s)
        {
            var arr = new List<byte>(102);

            var macs = s.Split(' ', ':', '-');

            for (var i = 0; i < 6; i++)
                arr.Add(0xff);

            for (var j = 0; j < 16; j++)
                for (var i = 0; i < 6; i++)
                    arr.Add(Convert.ToByte(macs[i], 16));

            return arr.ToArray();
        }

        public static void WakeUp(byte[] mac)
        {
            using (var udpClient = new UdpClient())
            {
                udpClient.Send(mac, mac.Length, new IPEndPoint(IPAddress.Broadcast, 9));
                //Console.WriteLine(mac.ToString());
            }
        }
    }
}