using Grpc.Net.Client;
using System;

namespace Loreggia.Delivery.Track.Autenticador.Shared.GRPCClient.Clients
{
    public interface IClient : IDisposable
    {
        string ServerGRPC { get; }
        GrpcChannel Channel { get; }
    }
}
