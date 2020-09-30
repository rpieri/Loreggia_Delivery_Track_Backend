using Loreggia.Delivery.Track.Autenticador.Shared.Application.Commands;
using System;

namespace Loreggia.Delivery.Track.Autenticador.Applications.QueryCommands.BuscarUsurio
{
    public sealed class BuscarUsuarioQueryCommand : QueryCommand<BuscarUsuarioQueryCommand>
    {
        public BuscarUsuarioQueryCommand(Guid codigo)
        {
            Codigo = codigo;
        }

        public Guid Codigo { get; private set; }
    }
}
