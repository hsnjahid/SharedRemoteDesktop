using RemoteDesktop.Grpc.Client.Core.Pocos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RemoteDesktop.Grpc.Client.Core
{
    public interface IGrpcClient
    {
        void Build(string address);
        Task<string> RegisterAsync(RemoteClientProxy clientProxy);

        Task<List<RemoteComputerProxy>> GetRemoteComputersAsync(string requestId);
    }
}