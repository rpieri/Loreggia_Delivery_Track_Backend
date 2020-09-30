using Loreggia.Delivery.Track.Autenticador.Shared.Application.CommandResults;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Commands;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Loreggia.Delivery.Track.Autenticador.Shared.Application.Handlers
{
    public abstract class CommandHandler<TCommand> : IRequestHandler<TCommand, CommandResult> where TCommand : Command<TCommand>
    {
        private readonly IMediatorHandler mediatorHandler;

        public CommandHandler(IMediatorHandler mediatorHandler) => this.mediatorHandler = mediatorHandler;
        public abstract Task<CommandResult> Handle(TCommand request, CancellationToken cancellationToken);

        protected async Task<CommandResult> SendCommandAsync<TNewCommand>(Command<TNewCommand> command) where TNewCommand : Command<TNewCommand>
            => await mediatorHandler.SendAsync(command);
    }
}
