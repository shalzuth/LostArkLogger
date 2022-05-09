using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;

// https://stackoverflow.com/questions/10789898/determine-which-network-adapter-a-process-is-using
namespace LostArkLogger.Utilities
{
    class NetworkUtil
    {
        public static NetworkInterface GetAdapterUsedByProcess(string pName)
        {
            Process[] candidates = Process.GetProcessesByName(pName);
            if (candidates.Length == 0)
                throw new Exception("Cannot find any running processes with the name " + pName + ".exe");

            IPAddress localAddr = null;
            using (Process p = candidates[0])
            {
                TcpTable table = ManagedIpHelper.GetExtendedTcpTable(true);
                foreach (TcpRow r in table)
                    if (r.ProcessId == p.Id)
                    {
                        localAddr = r.LocalEndPoint.Address;
                        break;
                    }
            }

            if (localAddr == null)
                throw new Exception("No routing information for " + pName + ".exe found.");

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                IPInterfaceProperties ipProps = nic.GetIPProperties();
                if (ipProps.UnicastAddresses.Any(new Func<UnicastIPAddressInformation, bool>((u) => { return u.Address.ToString() == localAddr.ToString(); })))
                    return nic;
            }
            return null;
        }
    }
}
