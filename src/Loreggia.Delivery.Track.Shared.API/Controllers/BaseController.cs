using Loreggia.Delivery.Track.Autenticador.Shared.Application.CommandResults;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Commands;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Interfaces;
using Loreggia.Delivery.Track.Autenticador.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Loreggia.Delivery.Track.Autenticador.Shared.API.Controllers
{
    public abstract class BaseController<TController> : ControllerBase where TController : BaseController<TController>
    {
        protected readonly IMediatorHandler mediator;
        private readonly ILogger<TController> logger;

        public BaseController(IMediatorHandler mediator, ILogger<TController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        protected async Task<IActionResult> ResponseBase(CommandResult commandResult)
        {
            if (commandResult != null)
            {
                if (commandResult.Success)
                {

                    return await Task.Run(() => new OkObjectResult(commandResult));
                }

                return await Task.Run(() => new BadRequestObjectResult(commandResult));
            }
            return await Task.Run(() => new BadRequestResult());
        }


        protected async Task<CommandResult> SendCommand<TCommand>(Command<TCommand> command) where TCommand : Command<TCommand>
            => await mediator.SendAsync(command);

        protected async Task<IActionResult> ReturnCommand<TCommand>(Command<TCommand> command) where TCommand : Command<TCommand>
        {
            var result = await SendCommand(command);
            return await ResponseBase(result);
        }
        protected async Task<IActionResult> Execute<TCommand, TViewModel>(TViewModel viewModel)
            where TCommand : Command<TCommand>
            where TViewModel : ViewModelToCommand<TCommand>
        {
            var command = viewModel.Mapping();
            return await ReturnCommand(command);
        }
    }
}
