using Loreggia.Delivery.Track.Autenticador.Shared.Application.CommandResults;
using MediatR;
using System.Threading.Tasks;

namespace Loreggia.Delivery.Track.Autenticador.Shared.Application.Interfaces
{
    public interface IMediatorHandler
    {
        Task<CommandResult> SendAsync<TCommand>(TCommand command) where TCommand : IRequest<CommandResult>;
    }
}
