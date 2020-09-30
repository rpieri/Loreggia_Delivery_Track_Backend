using Loreggia.Delivery.Track.Autenticador.Applications.EntityCommands.AdicionarUsuario;
using Loreggia.Delivery.Track.Autenticador.Cadastro.API.Protos;
using Loreggia.Delivery.Track.Autenticador.Shared.GRPC.Mappings;

namespace Loreggia.Delivery.Track.Autenticador.Cadastro.API.MapperProto
{
    public class AdicionarUsuarioCommandMapping : ProtobufToCommand<AdicionarUsuarioRequest, AdicionarUsuarioCommand>
    {
        public override AdicionarUsuarioCommand Mapper(AdicionarUsuarioRequest protobuf)
        {
            return new AdicionarUsuarioCommand(protobuf.CodigoEmpresa, protobuf.Nome, protobuf.Email, protobuf.Senha);
        }
    }
}
