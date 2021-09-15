using Grpc.Net.Client;
using RemoteDesktop.Common;
using RemoteDesktop.Grpc.Service.Genrated;
using RemoteDesktop.Grpc.Client.Core.Pocos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RemoteDesktop.Grpc.Client.Core
{
    public class GrpcClient : IGrpcClient
    {
        //Channel _channel = new ClientBase.("https://localhost:5001", ChannelCredentials.Insecure);
        #region Fields
        private ILogger _logger;
        private ControlRemoteComputer.ControlRemoteComputerClient _client;
        #endregion

        #region Constructors
        public GrpcClient(ILogger logger)
        {
        }
        #endregion


        #region Methods

        public void Build(string address)
        {
            var channel = GrpcChannel.ForAddress(address);
            _client = new ControlRemoteComputer.ControlRemoteComputerClient(channel);
        }

        public async Task<string> RegisterAsync(RemoteClientProxy clientProxy)
        {
            var response = await _client.SubscribeAsync(new SubscribeRequest { Client = clientProxy.ConvertBack() });

            return response.SubscribeId;
        }

        public async Task<List<RemoteComputerProxy>> GetRemoteComputersAsync(string requestId)
        {
            var remoteComputers = new List<RemoteComputerProxy>();

            var response = await _client.ResolveAvailableRemoteComputersAsync(new AvailableRemoteComputersRequest { RequestId = requestId });

            foreach (var item in response.RemoteComputerList)
            {
                await Task.Delay(5000);
                remoteComputers.Add(new RemoteComputerProxy(item));
            }

            return remoteComputers;
        }

        #endregion
    }
}
