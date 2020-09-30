using FluentValidation;
using FluentValidation.Results;

namespace Loreggia.Delivery.Track.Autenticador.Shared.Application.Commands
{
    public abstract class EntityCommand<TEntityCommand> : Command<TEntityCommand> where TEntityCommand : Command<TEntityCommand>
    {
        public bool Valid { get; private set; }

        public ValidationResult ValidationResult { get; protected set; }

        public bool Invalid => !Valid;

        protected bool CommandIsValid() => Valid = ValidationResult.IsValid;
        protected void InsertValidation(TEntityCommand model, AbstractValidator<TEntityCommand> validator)
            => ValidationResult = validator.Validate(model);

        public abstract bool Validate();
    }
}
