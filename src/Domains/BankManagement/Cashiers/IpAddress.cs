using CashierManagement.Common;
using System;

namespace CashierManagement.Cashiers
{
    public class IpAddress : ValueObject
    {
        public IpAddress(IpAddress address)
        {
        }

        public string Ip { get; set; }
        public int Port { get; set; }
        public bool isValidAddress(IpAddress address)
        {
            return isValidAddress(address.Ip, address.Port);
        }
        public bool isValidAddress(string Ip, int port)
        {
            if (string.IsNullOrEmpty(Ip))
            {
                throw new Exception("error");
            }
            if (port <= 0)
            {
                throw new Exception("error");
            }

            var splitIp = Ip.Split('.');
            if (splitIp.Length != 4)
            {
                throw new Exception("erro");
            }

            foreach (var partIp in splitIp)
            {
                int parInt;
                int.TryParse(partIp, out parInt);
                if (parInt < 0)
                {
                    throw new Exception("error");
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
