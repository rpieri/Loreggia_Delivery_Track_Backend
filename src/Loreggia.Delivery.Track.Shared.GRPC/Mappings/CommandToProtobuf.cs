using Google.Protobuf;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Commands;

namespace Loreggia.Delivery.Track.Autenticador.Shared.GRPC.Mappings
{
    public abstract class CommandToProtobuf<TCommand, TProtobuf> where TCommand : Command<TCommand> where TProtobuf : IMessage<TProtobuf>
    {
        public abstract TProtobuf Mapper(TCommand command);
    }
}
