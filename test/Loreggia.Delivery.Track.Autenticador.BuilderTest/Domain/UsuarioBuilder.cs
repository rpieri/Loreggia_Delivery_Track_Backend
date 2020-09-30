using Loreggia.Delivery.Track.Autenticador.Domain.Models;

namespace Loreggia.Delivery.Track.Autenticador.BuilderTest.Domain
{
    public sealed class UsuarioBuilder
    {
        private int? codigoEmpresa;
        private string nome;
        private string email;
        private string senha;

        public UsuarioBuilder()
        {
            nome = "UsuarioTeste";
            email = "usuarioteste@teste.com";
            senha = "123mudar";
        }

        public Usuario Builder() => new Usuario(codigoEmpresa, nome, email, senha);
        public UsuarioBuilder ComEmpresa(int? value)
        {
            codigoEmpresa = value;
            return this;
        }

        public UsuarioBuilder ComNome(string value)
        {
            nome = value;
            return this;
        }

        public UsuarioBuilder ComEmail(string value)
        {
            email = value;
            return this;
        }

        public UsuarioBuilder ComSenha(string value)
        {
            senha = value;
            return this;
        }
    }
}
