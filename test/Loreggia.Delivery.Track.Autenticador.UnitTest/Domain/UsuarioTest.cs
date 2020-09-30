using Loreggia.Delivery.Track.Autenticador.BuilderTest.Domain;
using Xunit;

namespace Loreggia.Delivery.Track.Autenticador.UnitTest.Domain
{
    public sealed class UsuarioTest
    {
        [Fact]
        public void Usuario_VerificarSenha_AoInformarUmaSenhaDiferente_RetornaVericacao_Falhou()
        {
            var senha2 = "1234mudar";
            var usuario = new UsuarioBuilder().Builder();

            Assert.False(usuario.VerificarSenha(senha2));
        }

        [Fact]
        public void Usuario_VerificarSenha_AoInformarAMesmaSenha_RetornaVericacao_Sucesso()
        {
            var senha = "1234mudar";
            var usuario = new UsuarioBuilder().ComSenha(senha).Builder();

            Assert.True(usuario.VerificarSenha(senha));
        }

        [Fact]
        public void Usuario_VerificarEmail_QuandoOEmailForVerificado_DeveSerSetadoPara_Verdadeiro()
        {
            var usuario = new UsuarioBuilder().Builder();
            Assert.False(usuario.EmailVerificado);

            usuario.VerificarEmail();
            Assert.True(usuario.EmailVerificado);
        }

        [Fact]
        public void Usuario_EmailFoiAlterado_RetornaQueEmailFoiAlterado()
        {
            const string NOVO_EMAIL = "t@t.com";
            var usuario = new UsuarioBuilder().Builder();

            Assert.True(usuario.EmailFoiAlterado(NOVO_EMAIL));
        }

        [Fact]
        public void Usuario_EmailFoiAlterado_RetornaQueEmailNaoFoiAlterado()
        {
            const string NOVO_EMAIL = "t@t.com";
            var usuario = new UsuarioBuilder().ComEmail(NOVO_EMAIL).Builder();

            Assert.False(usuario.EmailFoiAlterado(NOVO_EMAIL));
        }

        [Fact]
        public void Usuario_RemoverVerificacaoEmail_DeveRemoverAValidacaoDoEmail()
        {
            var usuario = new UsuarioBuilder().Builder();
            usuario.VerificarEmail();
            Assert.True(usuario.EmailVerificado);
            usuario.RemoverVerificacaoEmail();
            Assert.False(usuario.EmailVerificado);
        }
    }
}
