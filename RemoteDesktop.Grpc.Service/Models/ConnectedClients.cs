using System.Collections.Generic;

namespace RemoteDesktop.Grpc.Service
{
    internal sealed class ConnectedClientList
    {
        public List<ConnetedClient> Clients { get; set; }
    }

    internal sealed class ConnetedClient
    {
        public string UniqueId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EmailAddress { get; set; }
    }
}