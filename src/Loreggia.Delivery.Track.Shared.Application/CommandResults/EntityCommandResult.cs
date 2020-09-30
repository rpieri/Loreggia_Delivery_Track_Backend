using Loreggia.Delivery.Track.Autenticador.Shared.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Loreggia.Delivery.Track.Autenticador.Shared.Application.CommandResults
{
    public class EntityCommandResult : CommandResult
    {
        public EntityCommandResult(bool success, string message = "", object data = null, IList<string> validationErrors = null) : base(success, data)
        {
            Message = message;
            ValidationErrors = validationErrors ?? new List<string>();
        }

        public string Message { get; private set; }

        public void SetData(object data) => Data = data;
        public TEntity ConvertDataToEntity<TEntity>() where TEntity : Entity => Data as TEntity;

        #region Validations
        public IList<string> ValidationErrors { get; private set; }
        public bool HasAValidationError => ValidationErrors.Any();
        public void AddValidationError(string error) => ValidationErrors.Add(error);
        #endregion
    }
}
