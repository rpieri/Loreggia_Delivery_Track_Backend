using Loreggia.Delivery.Track.Autenticador.Shared.Application.Commands;

namespace Loreggia.Delivery.Track.Autenticador.Applications.QueryCommands.ListarUsuarios
{
    public sealed class ListarUsuariosQueryCommand : QueryCommand<ListarUsuariosQueryCommand>
    {
        public ListarUsuariosQueryCommand(int? codigoEmpresa)
        {
            CodigoEmpresa = codigoEmpresa;
        }

        public int? CodigoEmpresa { get; private set; }
    }
}
