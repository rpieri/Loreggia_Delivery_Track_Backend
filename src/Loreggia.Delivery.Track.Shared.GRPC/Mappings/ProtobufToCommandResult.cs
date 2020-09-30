using Google.Protobuf;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.CommandResults;

namespace Loreggia.Delivery.Track.Autenticador.Shared.GRPC.Mappings
{
    public abstract class ProtobufToCommandResult<TProtobuf, TCommandResult> where TProtobuf : IMessage<TProtobuf> where TCommandResult : CommandResult
    {
        public abstract TCommandResult Mapper(TProtobuf protobuf);
    }
}
