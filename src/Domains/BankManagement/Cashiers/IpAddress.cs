using BuildBlocks.Commons;
using System;

namespace CashierManagement.Cashiers
{
    public class IpAddress : ValueObject
    {
        public string Ip { get; set; }
        public int Port { get; set; }
        public IpAddress(IpAddress address)
        {
            if (isValidAddress(address))
            {
                Ip = address.Ip;
                Port = address.Port;
            }
        }
        public IpAddress(string ip, int port)
        {
            if (isValidAddress(ip, port))
            {
                Ip = ip;
                Port = port;
            }
        }
        public IpAddress(string IpAdressString)
        {
            var arr = IpAdressString.Split(':');
            if (arr.Length != 2)
            {
                throw new Exception("erro1");
            }
            int port;
            if (!int.TryParse(arr[1], out port))
            {
                throw new Exception("erro2");
            }
            if (isValidAddress(arr[0], port))
            {
                Ip = arr[0];
                Port = port;
            }
        }
        public bool isValidAddress(IpAddress address)
        {
            return isValidAddress(address.Ip, address.Port);
        }
        public bool isValidAddress(string Ip, int port)
        {
            if (string.IsNullOrEmpty(Ip))
            {
                throw new Exception("erro3");
            }
            if (port <= 0)
            {
                throw new Exception("error4");
            }

            var splitIp = Ip.Split('.');
            if (splitIp.Length != 4)
            {
                throw new Exception("erro5");
            }
            foreach (var partIp in splitIp)
            {
                int parInt;
                int.TryParse(partIp, out parInt);
                if (parInt < 0)
                {
                    throw new Exception("error6");
                }
            }
            return true;
        }
        public override string ToString()
        {
            return Ip + ":" + Port;
        }
    }
}
