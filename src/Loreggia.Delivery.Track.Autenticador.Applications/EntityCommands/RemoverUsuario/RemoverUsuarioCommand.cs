using FluentValidation;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Commands;
using System;

namespace Loreggia.Delivery.Track.Autenticador.Applications.EntityCommands.RemoverUsuario
{
    public sealed class RemoverUsuarioCommand : EntityCommand<RemoverUsuarioCommand>
    {
        public RemoverUsuarioCommand(Guid codigo)
        {
            Codigo = codigo;
        }

        public Guid Codigo { get; private set; }
        public override bool Validate()
        {
            InsertValidation(this, new RemoverUsuarioCommandValidator());
            return CommandIsValid();
        }
    }

    internal sealed class RemoverUsuarioCommandValidator : AbstractValidator<RemoverUsuarioCommand>
    {
        public RemoverUsuarioCommandValidator()
        {
            RuleFor(e => e.Codigo)
                .NotEmpty();
        }
    }
}
