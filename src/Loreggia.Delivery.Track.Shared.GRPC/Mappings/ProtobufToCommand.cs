using Google.Protobuf;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Commands;

namespace Loreggia.Delivery.Track.Autenticador.Shared.GRPC.Mappings
{
    public abstract class ProtobufToCommand<TProtobuf, TCommand> where TProtobuf : IMessage<TProtobuf> where TCommand : Command<TCommand>
    {
        public abstract TCommand Mapper(TProtobuf protobuf);
    }
}
