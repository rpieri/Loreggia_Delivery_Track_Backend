using Loreggia.Delivery.Track.Autenticador.Shared.Application.CommandResults;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Commands;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Interfaces;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Mappings;
using Loreggia.Delivery.Track.Autenticador.Shared.Domain.Models;
using Loreggia.Delivery.Track.Autenticador.Shared.Domain.Notifications;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loreggia.Delivery.Track.Autenticador.Shared.Application.Handlers
{
    public abstract class EntityCommandHandler<TEntity, TCommand> : CommandHandler<TCommand> where TEntity : Entity where TCommand : Command<TCommand>
    {
        private readonly ILogger<TCommand> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly NotificationContext notificationContext;

        protected EntityCommandHandler(
            ILogger<TCommand> logger,
            IUnitOfWork unitOfWork,
            NotificationContext notificationContext,
            IMediatorHandler mediatorHandler) : base(mediatorHandler)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.notificationContext = notificationContext;
        }

        protected bool Valid(TEntity entity)
        {
            if (entity.Invalid)
            {
                notificationContext.AddNotification(entity.ValidationResult);
                return false;
            }
            return true;
        }

        protected async Task<EntityCommandResult> CommitAsync(TCommand command, string message)
        {
            var entityMapper = await MapperAsync(command);
            if (entityMapper.HasAProblem)
            {
                return CreateEntityCommandResult(entityMapper.Success, entityMapper.Message);
            }

            var entity = entityMapper.Entity;
            if (!await ValidateAndExecuteCommandAsync(entity))
            {
                return CreateEntityCommandResult(false);
            }

            if (await unitOfWork.CommitAsync())
            {
                return CreateEntityCommandResult(true, message, entity);
            }

            return CreateEntityCommandResult(false);
        }

        protected async Task<bool> ValidateAndExecuteCommandAsync(TEntity entity)
        {
            if (Valid(entity))
            {
                await ExecuteCommandAsync(entity);
                return true;
            }
            return false;
        }

        protected abstract Task<EntityMapper<TEntity>> MapperAsync(TCommand command);

        protected abstract Task ExecuteCommandAsync(TEntity entity);

        protected EntityCommandResult CreateEntityCommandResult(bool success, string message = "", object data = null)
        {
            var entityCommandResult = new EntityCommandResult(success, message, data);
            if (entityCommandResult.HasAProblem && notificationContext.HasNotification)
            {
                var log = new StringBuilder();
                notificationContext.Notifications.ToList().ForEach(error =>
                {
                    entityCommandResult.AddValidationError(error.Message);
                    log.Append(error.Message);
                });
                logger.LogError(log.ToString());
            }
            return entityCommandResult;
        }
    }
}
