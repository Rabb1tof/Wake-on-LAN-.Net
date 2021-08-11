﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Wake_on_LAN.Net
{
    internal class PcData
    {
        public string Name;
        public string Mac;
        public byte[] MacBytes;

        public PcData(string name, string mac, byte[] macBytes)
        {
            this.Name = name;
            this.Mac = mac;
            this.MacBytes = macBytes;
        }

        public static byte[] StrToMac(string s)
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

        public static void WakeUp(byte[] mac)
        {
            using (UdpClient udpClient = new UdpClient())
            {
                udpClient.Send(mac, mac.Length, new IPEndPoint(IPAddress.Broadcast, 9));
                //Console.WriteLine(mac.ToString());
            }
        }
    }
}
