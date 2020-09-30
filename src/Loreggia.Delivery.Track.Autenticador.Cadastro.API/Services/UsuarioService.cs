using Grpc.Core;
using Loreggia.Delivery.Track.Autenticador.Cadastro.API.MapperProto;
using Loreggia.Delivery.Track.Autenticador.Cadastro.API.Protos;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Interfaces;
using System.Threading.Tasks;

namespace Loreggia.Delivery.Track.Autenticador.Cadastro.API.Services
{
    public class UsuarioService : Usuario.UsuarioBase
    {
        private readonly AdicionarUsuarioCommandMapping adicionarUsuarioCommandMapping;
        private readonly UsuarioCommandResultMapping usuarioCommandResultMapping;
        private readonly IMediatorHandler mediator;

        public UsuarioService(
            AdicionarUsuarioCommandMapping adicionarUsuarioCommandMapping,
            UsuarioCommandResultMapping usuarioCommandResultMapping,
            IMediatorHandler mediator)
        {
            this.adicionarUsuarioCommandMapping = adicionarUsuarioCommandMapping;
            this.usuarioCommandResultMapping = usuarioCommandResultMapping;
            this.mediator = mediator;
        }
        public override async Task<UsuarioResponse> AdicionarUsuario(AdicionarUsuarioRequest request, ServerCallContext context)
        {
            var command = adicionarUsuarioCommandMapping.Mapper(request);
            return usuarioCommandResultMapping.Mapper(await mediator.SendAsync(command));
        }
    }
}
