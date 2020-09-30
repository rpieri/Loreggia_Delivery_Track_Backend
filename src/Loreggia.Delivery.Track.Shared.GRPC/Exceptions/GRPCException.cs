using System;

namespace Loreggia.Delivery.Track.Autenticador.Shared.GRPC.Exceptions
{
    public sealed class GRPCException : Exception
    {
        public GRPCException(string server, string message) : base($"Server: {server} => Error: {message}") { }
    }
}
