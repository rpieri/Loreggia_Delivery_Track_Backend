using Loreggia.Delivery.Track.Autenticador.Domain.Models;
using Loreggia.Delivery.Track.Autenticador.Domain.Repositories;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.CommandResults;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Handlers;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Interfaces;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Mappings;
using Loreggia.Delivery.Track.Autenticador.Shared.Domain.Notifications;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Loreggia.Delivery.Track.Autenticador.Applications.EntityCommands.RemoverUsuario
{
    public sealed class RemoverUsuarioCommandHandler : EntityCommandHandler<Usuario, RemoverUsuarioCommand>
    {
        private readonly IUsuarioRepository repository;

        public RemoverUsuarioCommandHandler(
            IUsuarioRepository repository,
            ILogger<RemoverUsuarioCommand> logger,
            IUnitOfWork unitOfWork,
            NotificationContext notificationContext,
            IMediatorHandler mediatorHandler) : base(logger, unitOfWork, notificationContext, mediatorHandler)
        {
            this.repository = repository;
        }

        public override async Task<CommandResult> Handle(RemoverUsuarioCommand request, CancellationToken cancellationToken) => await CommitAsync(request, "Usuário apagado com sucesso");

        protected override async Task ExecuteCommandAsync(Usuario entity) => await repository.AtualizarAsync(entity);

        protected override async Task<EntityMapper<Usuario>> MapperAsync(RemoverUsuarioCommand command)
        {
            var usuario = await repository.BuscarAsync(command.Codigo);
            if (usuario == null)
            {
                return new EntityMapper<Usuario>(false, "Usuário não encontrado");
            }

            usuario.Apagar();
            return new EntityMapper<Usuario>(true, "", usuario);
        }
    }
}
