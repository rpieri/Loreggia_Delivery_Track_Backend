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

namespace Loreggia.Delivery.Track.Autenticador.Applications.EntityCommands.AdicionarUsuario
{
    public sealed class AdicionarUsuarioCommandHandler : EntityCommandHandler<Usuario, AdicionarUsuarioCommand>
    {
        private readonly IUsuarioRepository usuarioRepository;

        public AdicionarUsuarioCommandHandler(
            IUsuarioRepository usuarioRepository,
            ILogger<AdicionarUsuarioCommand> logger,
            IUnitOfWork unitOfWork,
            NotificationContext notificationContext,
            IMediatorHandler mediatorHandler) : base(logger, unitOfWork, notificationContext, mediatorHandler)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public override async Task<CommandResult> Handle(AdicionarUsuarioCommand request, CancellationToken cancellationToken) => await CommitAsync(request, "Usuário cadastrado com sucesso");

        protected override async Task ExecuteCommandAsync(Usuario entity) => await usuarioRepository.AdicionarAsync(entity);

        protected override async Task<EntityMapper<Usuario>> MapperAsync(AdicionarUsuarioCommand command)
        {
            if (await usuarioRepository.EmailJaCadastradoAsync(command.Email))
            {
                return new EntityMapper<Usuario>(false, "E-mail já cadastrado");
            }

            return new EntityMapper<Usuario>(true, "", new Usuario(command.CodigoEmpresa, command.Nome, command.Email, command.Senha));
        }
    }
}
