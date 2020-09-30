using Loreggia.Delivery.Track.Autenticador.Shared.Application.CommandResults;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Messages;
using MediatR;

namespace Loreggia.Delivery.Track.Autenticador.Shared.Application.Commands
{
    public abstract class Command<TCommand> : Message<TCommand>, IRequest<CommandResult> where TCommand : Command<TCommand>
    {
    }
}
