using Loreggia.Delivery.Track.Autenticador.Domain.Repositories;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.CommandResults;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Handlers;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Loreggia.Delivery.Track.Autenticador.Applications.QueryCommands.BuscarUsurio
{
    public class BuscarUsuarioQueryCommandHandler : CommandHandler<BuscarUsuarioQueryCommand>
    {
        private readonly IUsuarioReadOnlyRepository readOnlyRepository;

        public BuscarUsuarioQueryCommandHandler(
            IUsuarioReadOnlyRepository readOnlyRepository,
            IMediatorHandler mediatorHandler) : base(mediatorHandler)
        {
            this.readOnlyRepository = readOnlyRepository;
        }

        public override async Task<CommandResult> Handle(BuscarUsuarioQueryCommand request, CancellationToken cancellationToken)
        {
            var usuario = await readOnlyRepository.BuscarAsync(request.Codigo);
            return new QueryCommandResult(true, usuario);
        }
    }
}
