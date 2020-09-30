using Google.Protobuf;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.CommandResults;

namespace Loreggia.Delivery.Track.Autenticador.Shared.GRPC.Mappings
{
    public abstract class CommandResultToPrototype<TProtobuf, TCommandResult> where TProtobuf : IMessage<TProtobuf> where TCommandResult : CommandResult
    {
        public abstract TProtobuf Mapper(TCommandResult commandResult);
    }
}
