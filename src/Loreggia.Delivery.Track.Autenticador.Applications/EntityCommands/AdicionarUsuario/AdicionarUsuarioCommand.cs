using FluentValidation;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Commands;

namespace Loreggia.Delivery.Track.Autenticador.Applications.EntityCommands.AdicionarUsuario
{
    public sealed class AdicionarUsuarioCommand : EntityCommand<AdicionarUsuarioCommand>
    {
        public AdicionarUsuarioCommand(int? codigoEmpresa, string nome, string email, string senha)
        {
            CodigoEmpresa = codigoEmpresa;
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public int? CodigoEmpresa { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public override bool Validate()
        {
            InsertValidation(this, new AdicionarUsuarioCommandValidator());
            return CommandIsValid();
        }
    }

    internal sealed class AdicionarUsuarioCommandValidator : AbstractValidator<AdicionarUsuarioCommand>
    {
        internal AdicionarUsuarioCommandValidator()
        {
            RuleFor(e => e.Nome)
                .NotEmpty()
                .MaximumLength(250);
            RuleFor(e => e.Email)
                .NotEmpty()
                .MaximumLength(250)
                .EmailAddress();
            RuleFor(e => e.Senha)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(12);
        }
    }
}
