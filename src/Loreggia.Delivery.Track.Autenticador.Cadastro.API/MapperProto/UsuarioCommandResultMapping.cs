using Google.Protobuf.Collections;
using Loreggia.Delivery.Track.Autenticador.Cadastro.API.Protos;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.CommandResults;
using Loreggia.Delivery.Track.Autenticador.Shared.GRPC.Mappings;
using System.Linq;

namespace Loreggia.Delivery.Track.Autenticador.Cadastro.API.MapperProto
{
    public class UsuarioCommandResultMapping : CommandResultToPrototype<UsuarioResponse, CommandResult>
    {
        public override UsuarioResponse Mapper(CommandResult commandResult)
        {
            var command = commandResult as EntityCommandResult;
            var usuarioResponse = new UsuarioResponse()
            {
                Success = command.Success,
                HasAProblem = command.HasAProblem,
                HasAValidationError = command.HasAValidationError,
                Message = command.Message
            };

            if (command.HasAValidationError)
            {
                usuarioResponse.ValidationErrors.AddRange(command.ValidationErrors);
            }
            return usuarioResponse;
        }
    }
}
