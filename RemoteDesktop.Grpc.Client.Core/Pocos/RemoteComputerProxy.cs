using RemoteDesktop.Grpc.Service.Genrated;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteDesktop.Grpc.Client.Core.Pocos
{
    public class RemoteComputerProxy
    {
        public string Name { get; set; }

        public string Ip { get; set; }
        public RemoteComputerProxy(RemoteComputer remoteComputer)
        {
            Name = remoteComputer.ComputerName;
            Ip = remoteComputer.IpAddress;
        }

    }
}
