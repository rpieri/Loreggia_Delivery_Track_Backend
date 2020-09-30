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

namespace Loreggia.Delivery.Track.Autenticador.Applications.EntityCommands.EditarUsuario
{
    public sealed class EditarUsuarioCommandHandler : EntityCommandHandler<Usuario, EditarUsuarioCommand>
    {
        private readonly IUsuarioRepository repository;

        public EditarUsuarioCommandHandler(
            IUsuarioRepository repository,
            ILogger<EditarUsuarioCommand> logger,
            IUnitOfWork unitOfWork,
            NotificationContext notificationContext,
            IMediatorHandler mediatorHandler) : base(logger, unitOfWork, notificationContext, mediatorHandler)
        {
            this.repository = repository;
        }

        public override async Task<CommandResult> Handle(EditarUsuarioCommand request, CancellationToken cancellationToken)
        {
            return await CommitAsync(request, "Usuario editado com sucesso");
        }

        protected override async Task ExecuteCommandAsync(Usuario entity) => await repository.AtualizarAsync(entity);

        protected override async Task<EntityMapper<Usuario>> MapperAsync(EditarUsuarioCommand command)
        {
            var usuario = await repository.BuscarAsync(command.Codigo);
            if (usuario == null)
            {
                return new EntityMapper<Usuario>(false, "Usuário não foi encontrado");
            }

            if (usuario.EmailFoiAlterado(command.Email))
            {
                if (await repository.EmailJaCadastradoAsync(command.Email))
                {
                    return new EntityMapper<Usuario>(false, $"E-mail: {command.Email} já esta cadastrado no sistema");
                }
                usuario.RemoverVerificacaoEmail();
            }

            usuario.AtualizarUsuario(command.Nome, command.Email, command.Senha);

            return new EntityMapper<Usuario>(true, "", usuario);
        }
    }
}
