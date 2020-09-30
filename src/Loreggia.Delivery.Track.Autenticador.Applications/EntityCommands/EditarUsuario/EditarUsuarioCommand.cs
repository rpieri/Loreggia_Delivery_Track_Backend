using FluentValidation;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Commands;
using System;

namespace Loreggia.Delivery.Track.Autenticador.Applications.EntityCommands.EditarUsuario
{
    public sealed class EditarUsuarioCommand : EntityCommand<EditarUsuarioCommand>
    {
        public EditarUsuarioCommand(Guid codigo, string nome, string email, string senha)
        {
            Codigo = codigo;
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public Guid Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public override bool Validate()
        {
            InsertValidation(this, new EditarUsuarioCommandValidator());
            return CommandIsValid();
        }
    }

    internal sealed class EditarUsuarioCommandValidator : AbstractValidator<EditarUsuarioCommand>
    {
        public EditarUsuarioCommandValidator()
        {
            RuleFor(e => e.Codigo)
                .NotEmpty();
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
