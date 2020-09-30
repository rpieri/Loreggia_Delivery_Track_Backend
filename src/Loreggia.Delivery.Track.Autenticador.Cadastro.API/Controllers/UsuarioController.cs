using Loreggia.Delivery.Track.Autenticador.Applications.EntityCommands.AdicionarUsuario;
using Loreggia.Delivery.Track.Autenticador.Applications.EntityCommands.EditarUsuario;
using Loreggia.Delivery.Track.Autenticador.Applications.EntityCommands.RemoverUsuario;
using Loreggia.Delivery.Track.Autenticador.Applications.QueryCommands.BuscarUsurio;
using Loreggia.Delivery.Track.Autenticador.Applications.QueryCommands.ListarUsuarios;
using Loreggia.Delivery.Track.Autenticador.Cadastro.API.ViewModels;
using Loreggia.Delivery.Track.Autenticador.Shared.API.Controllers;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Loreggia.Delivery.Track.Autenticador.Cadastro.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsuarioController : BaseController<UsuarioController>
    {
        public UsuarioController(IMediatorHandler mediator, ILogger<UsuarioController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get() => await ReturnCommand(new ListarUsuariosQueryCommand(null));

        [HttpGet("{codigo}")]
        public async Task<IActionResult> Get(Guid codigo) => await ReturnCommand(new BuscarUsuarioQueryCommand(codigo));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdicionarUsuarioViewModel viewModel)
            => await Execute<AdicionarUsuarioCommand, AdicionarUsuarioViewModel>(viewModel);

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditarUsuarioViewModel viewModel)
            => await Execute<EditarUsuarioCommand, EditarUsuarioViewModel>(viewModel);

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(Guid codigo) => await ReturnCommand(new RemoverUsuarioCommand(codigo));
    }
}
