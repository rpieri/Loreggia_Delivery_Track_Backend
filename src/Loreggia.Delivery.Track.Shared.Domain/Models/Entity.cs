using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loreggia.Delivery.Track.Autenticador.Shared.Domain.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            Codigo = Guid.NewGuid();
            Apagado = false;
            Valid = true;
            DataDeCriacao = DateTime.UtcNow;
        }
        public Guid Codigo { get; private set; }
        public bool Apagado { get; private set; }
        public DateTime DataDeCriacao { get; private set; }

        public void Apagar() => Apagado = true;

        #region Validation
        public bool Valid { get; private set; }
        public ValidationResult ValidationResult { get; private set; }
        public bool Invalid => !Valid;
        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator) where TModel : Entity
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }

        #endregion

        #region Comparative
        protected abstract IEnumerable<object> GetEqualityComponents();

        public bool Equal(Entity obj) => this == obj;
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (!(obj is Entity)) return false;

            return this == (obj as Entity);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 30;

                foreach (var item in GetEqualityComponents())
                {
                    hash = HashCode.Combine(hash, item) * 31;
                }

                return hash;
            }
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (a is null || b is null)
                return false;

            return a.GetType() == b.GetType() &&
                a.GetEqualityComponents().SequenceEqual(b.GetEqualityComponents());
        }

        public static bool operator !=(Entity a, Entity b) => !(a == b);
        #endregion
    }
}
