using Loreggia.Delivery.Track.Autenticador.Shared.Application.CommandResults;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Interfaces;
using MediatR;
using System.Threading.Tasks;

namespace Loreggia.Delivery.Track.Autenticador.Shared.Application.Handlers
{
    internal sealed class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator mediator;

        public MediatorHandler(IMediator mediator) => this.mediator = mediator;

        public async Task<CommandResult> SendAsync<TCommand>(TCommand command) where TCommand : IRequest<CommandResult>
            => await mediator.Send(command);
    }
}
