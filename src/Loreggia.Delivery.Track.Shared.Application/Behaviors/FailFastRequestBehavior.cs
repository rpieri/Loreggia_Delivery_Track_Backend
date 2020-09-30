using Loreggia.Delivery.Track.Autenticador.Shared.Application.CommandResults;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Loreggia.Delivery.Track.Autenticador.Shared.Application.Behaviors
{
    public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : Command<TRequest> where TResponse : CommandResult
    {
        private readonly ILogger<TRequest> logger;

        public FailFastRequestBehavior(ILogger<TRequest> logger) => this.logger = logger;
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is EntityCommand<TRequest>)
            {
                var entityRequest = request as EntityCommand<TRequest>;
                if (!entityRequest.Validate())
                {
                    var log = new StringBuilder();
                    var response = new EntityCommandResult(false);
                    entityRequest.ValidationResult.Errors.ToList().ForEach(error =>
                    {
                        response.AddValidationError(error.ErrorMessage);
                        log.Append(error.ErrorMessage);
                    });

                    logger.LogError(log.ToString());
                    return Task.FromResult(response as TResponse);
                }
            }

            return next();
        }
    }
}
