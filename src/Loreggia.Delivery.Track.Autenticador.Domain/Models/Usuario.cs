using FluentValidation;
using Loreggia.Delivery.Track.Autenticador.Shared.Domain.Models;
using Loreggia.Delivery.Track.Autenticador.Shared.Helper.Encryptions;
using System.Collections.Generic;

namespace Loreggia.Delivery.Track.Autenticador.Domain.Models
{
    public sealed class Usuario : Entity
    {
        private Usuario()
        {

        }

        public Usuario(int? codigoEmpresa, string nome, string email, string senha)
        {
            CodigoEmpresa = codigoEmpresa;
            EmailVerificado = false;
            AtualizarUsuario(nome, email, senha);
        }

        public int? CodigoEmpresa { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public bool EmailVerificado { get; private set; }

        public void AtualizarUsuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha.Encrypty();
            Validate(this, new UsuarioValidator());
        }

        public bool VerificarSenha(string senha) => Senha.Equals(senha.Encrypty());
        public bool VerificarEmail() => EmailVerificado = true;
        public bool RemoverVerificacaoEmail() => EmailVerificado = false;

        public bool EmailFoiAlterado(string email) => !Email.Equals(email);

        protected override IEnumerable<object> GetEqualityComponents() => new object[] { CodigoEmpresa, Nome, Email, Senha };
    }

    internal class UsuarioValidator : AbstractValidator<Usuario>
    {
        internal UsuarioValidator()
        {
            RuleFor(e => e.Nome)
                .NotEmpty()
                .MaximumLength(250);
            RuleFor(e => e.Email)
                .NotEmpty()
                .MaximumLength(250)
                .EmailAddress();
            RuleFor(e => e.Senha)
                .NotEmpty();
        }
    }
}
