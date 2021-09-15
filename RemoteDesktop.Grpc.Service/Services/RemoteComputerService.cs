using Grpc.Core;
using Microsoft.Extensions.Logging;
using RemoteDesktop.Grpc.Service.Genrated;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RemoteDesktop.Grpc.Service
{
    public class RemoteComputerService : ControlRemoteComputer.ControlRemoteComputerBase

    {
        #region Fields

        private readonly ILogger<RemoteComputerService> _logger;
        private object _guard = new object();
        private int _counter = new Random().Next(91000, 99999);
        private Random _randomGenerator = new Random(DateTime.Now.Second);

        private static List<RemoteComputer> _remoteComputers = new List<RemoteComputer>()
        {
            new RemoteComputer() { ComputerName = "WKS_Hossain", IpAddress = "192.168.1.100" },
            new RemoteComputer() { ComputerName = "WKS_Tobi", IpAddress = "192.168.1.200" },
        };

        private static List<ConnetedClient> _clients = new List<ConnetedClient>();

        #endregion

        #region Contructors

        public RemoteComputerService(ILogger<RemoteComputerService> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Services

        public override async Task<SubscribeRespose> Subscribe(SubscribeRequest request, ServerCallContext context)
        {
            var customerId = GetClientId();

            var response = new SubscribeRespose() { SubscribeId = customerId };

            await Task.Run(() =>
            {
                _clients.Add(new ConnetedClient() { UniqueId = customerId, FirstName = request.Client.FirstName, LastName = request.Client.LastName });
            });

            return response;
        }

        public override async Task<AvailableRemoteComputersResponse> ResolveAvailableRemoteComputers(AvailableRemoteComputersRequest request, ServerCallContext context)
        {
            var response = new AvailableRemoteComputersResponse() { RequestId = request.RequestId };

            await Task.Run(() =>
            {
                response.RemoteComputerList.AddRange(_remoteComputers);
            });

            await Task.Delay(5000);

            return response;
        }

        #endregion
        private string GetClientId() => $"RDC_{ _randomGenerator.Next(91000, 99999)}";
    }
}
