using Loreggia.Delivery.Track.Autenticador.Applications.EntityCommands.AdicionarUsuario;
using Loreggia.Delivery.Track.Autenticador.BuilderTest.Commands;
using Loreggia.Delivery.Track.Autenticador.Domain.Repositories;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.CommandResults;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Interfaces;
using Loreggia.Delivery.Track.Autenticador.Shared.Domain.Notifications;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Loreggia.Delivery.Track.Autenticador.UnitTest.CommandHandlers
{
    public sealed class AdicionarUsuarioCommandHandlerTest
    {
        private readonly IUsuarioRepository usuarioRepositoryMock;
        private readonly AdicionarUsuarioCommandHandler handler;

        public AdicionarUsuarioCommandHandlerTest()
        {
            usuarioRepositoryMock = Substitute.For<IUsuarioRepository>();

            var unitOfWorkMock = Substitute.For<IUnitOfWork>();
            unitOfWorkMock.CommitAsync().Returns(true);

            handler = new AdicionarUsuarioCommandHandler(
                usuarioRepositoryMock, 
                Substitute.For<ILogger<AdicionarUsuarioCommand>>(), 
                unitOfWorkMock, 
                new NotificationContext(), 
                Substitute.For<IMediatorHandler>());
        }

        [Fact]
        public async Task AdicionarUsuarioCommandHandler_AoAdicionarUmUsuario_EJaExisteOEmail_DeveRetornar_QueTemUmProblema()
        {
            const string MESSAGE = "E-mail já cadastrado";
            var command = new AdicionarUsuarioCommandBuilder().Builder();

            usuarioRepositoryMock.EmailJaCadastradoAsync(command.Email).Returns(true);

            var result = await handler.Handle(command, new CancellationToken()) as EntityCommandResult;

            Assert.True(result.HasAProblem);
            Assert.Equal(MESSAGE, result.Message);
        }

        [Fact]
        public async Task AdicionarUsuarioCommandHandler_AdicionarUsuario_ComSucesso()
        {
            var command = new AdicionarUsuarioCommandBuilder().Builder();

            usuarioRepositoryMock.EmailJaCadastradoAsync(command.Email).Returns(false);

            var result = await handler.Handle(command, new CancellationToken()) as EntityCommandResult;

            Assert.True(result.Success);
        }

    }
}
