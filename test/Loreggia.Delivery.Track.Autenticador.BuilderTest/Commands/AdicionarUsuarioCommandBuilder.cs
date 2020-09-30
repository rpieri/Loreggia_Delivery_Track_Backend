using Loreggia.Delivery.Track.Autenticador.Applications.EntityCommands.AdicionarUsuario;

namespace Loreggia.Delivery.Track.Autenticador.BuilderTest.Commands
{
    public sealed class AdicionarUsuarioCommandBuilder
    {
        private int? codigoEmpresa;
        private string nome;
        private string email;
        private string senha;

        public AdicionarUsuarioCommandBuilder()
        {
            codigoEmpresa = new int?();
            nome = "Novo Usuario";
            email = "novousuario@email.com";
            senha = "123mudar";
        }

        public AdicionarUsuarioCommand Builder() => new AdicionarUsuarioCommand(codigoEmpresa, nome, email, senha);

        public AdicionarUsuarioCommandBuilder ComCodigoEmpresa(int? value)
        {
            codigoEmpresa = value;
            return this;
        }

        public AdicionarUsuarioCommandBuilder ComNome(string value)
        {
            nome = value;
            return this;
        }

        public AdicionarUsuarioCommandBuilder ComSenha(string value)
        {
            senha = value;
            return this;
        }

        public AdicionarUsuarioCommandBuilder ComEmail(string value)
        {
            email = value;
            return this;
        }
    }
}
