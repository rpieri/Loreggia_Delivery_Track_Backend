using Loreggia.Delivery.Track.Autenticador.Domain.Repositories;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.CommandResults;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Handlers;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Loreggia.Delivery.Track.Autenticador.Applications.QueryCommands.ListarUsuarios
{
    public sealed class ListarUsuariosQueryCommandHandler : CommandHandler<ListarUsuariosQueryCommand>
    {
        private readonly IUsuarioReadOnlyRepository readOnlyRepository;

        public ListarUsuariosQueryCommandHandler(
            IUsuarioReadOnlyRepository readOnlyRepository,
            IMediatorHandler mediatorHandler) : base(mediatorHandler)
        {
            this.readOnlyRepository = readOnlyRepository;
        }

        public override async Task<CommandResult> Handle(ListarUsuariosQueryCommand request, CancellationToken cancellationToken)
        {
            var usuarios = await readOnlyRepository.BuscarAsync(request.CodigoEmpresa);
            return new QueryCommandResult(true, usuarios, usuarios.Count());
        }
    }
}
