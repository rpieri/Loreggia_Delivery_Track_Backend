using Grpc.Net.Client;
using System;

namespace Loreggia.Delivery.Track.Autenticador.Shared.GRPCClient.Clients
{
    public sealed class Client : IClient
    {
        public Client(string serverGRPC)
        {
            ServerGRPC = serverGRPC;
            if (!ServerGRPC.StartsWith("https"))
            {
                AppContext.SetSwitch(
                    "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            }

            Channel = GrpcChannel.ForAddress(ServerGRPC);
        }

        public string ServerGRPC { get; }

        public GrpcChannel Channel { get; }

        public void Dispose() => Channel.Dispose();
    }
}
