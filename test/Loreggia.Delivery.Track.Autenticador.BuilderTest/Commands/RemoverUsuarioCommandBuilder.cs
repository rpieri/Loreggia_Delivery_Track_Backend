using Loreggia.Delivery.Track.Autenticador.Applications.EntityCommands.RemoverUsuario;
using System;

namespace Loreggia.Delivery.Track.Autenticador.BuilderTest.Commands
{
    public sealed class RemoverUsuarioCommandBuilder
    {
        private Guid codigo;
        public RemoverUsuarioCommandBuilder()
        {
            codigo = Guid.NewGuid();
        }

        public RemoverUsuarioCommand Builder() => new RemoverUsuarioCommand(codigo);

        public RemoverUsuarioCommandBuilder ComCodigo(Guid value)
        {
            codigo = value;
            return this;
        }
    }
}
