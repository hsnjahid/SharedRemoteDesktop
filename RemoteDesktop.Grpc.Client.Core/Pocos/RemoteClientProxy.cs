using RemoteDesktop.Grpc.Service.Genrated;

namespace RemoteDesktop.Grpc.Client.Core.Pocos
{
    public class RemoteClientProxy
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string EmailAddress { get; private set; }

        public RemoteClientProxy(RemoteClient client)
        {
            Convert(client);
        }

        private void Convert(RemoteClient client)
        {
            this.FirstName = client.FirstName;
            this.LastName = client.LastName;
            this.EmailAddress = client.EmailAddress;
        }

        public RemoteClient ConvertBack()
        {
            var msg = new RemoteClient();
            msg.FirstName = FirstName;
            msg.LastName = LastName;
            msg.EmailAddress = EmailAddress;
            return msg;
        }
    }
}
