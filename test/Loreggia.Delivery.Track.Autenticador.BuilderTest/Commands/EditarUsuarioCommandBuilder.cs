using Loreggia.Delivery.Track.Autenticador.Applications.EntityCommands.EditarUsuario;
using System;

namespace Loreggia.Delivery.Track.Autenticador.BuilderTest.Commands
{
    public sealed class EditarUsuarioCommandBuilder
    {
        private Guid codigo;
        private string nome;
        private string email;
        private string senha;

        public EditarUsuarioCommandBuilder()
        {
            codigo = Guid.NewGuid();
            nome = "usuario_editado";
            email = "usuario@usuario.Editado.com";
            senha = "098mudar";
        }

        public EditarUsuarioCommand Builder() => new EditarUsuarioCommand(codigo, nome, email, senha);

        public EditarUsuarioCommandBuilder ComCodigo(Guid value)
        {
            codigo = value;
            return this;
        }

        public EditarUsuarioCommandBuilder ComNome(string value)
        {
            nome = value;
            return this;
        }

        public EditarUsuarioCommandBuilder ComSenha(string value)
        {
            senha = value;
            return this;
        }

        public EditarUsuarioCommandBuilder ComEmail(string value)
        {
            email = value;
            return this;
        }

    }
}
