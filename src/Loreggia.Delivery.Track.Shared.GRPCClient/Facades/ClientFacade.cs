using Loreggia.Delivery.Track.Autenticador.Shared.GRPC.Exceptions;
using Loreggia.Delivery.Track.Autenticador.Shared.GRPCClient.Clients;
using System.Collections.Generic;
using System.Linq;

namespace Loreggia.Delivery.Track.Autenticador.Shared.GRPCClient.Facades
{
    public sealed class ClientFacade
    {
        private readonly IEnumerable<IClient> clients;

        public ClientFacade(IEnumerable<IClient> clients)
        {
            this.clients = clients;
        }

        public IClient Client(string serverGRPC)
        {
            var client = clients.FirstOrDefault(x => x.ServerGRPC.Equals(serverGRPC));
            if (client == null)
            {
                throw new GRPCException(serverGRPC, "The GRPC Client was not found corresponding to the server");
            }
            return client;
        }
    }
}
