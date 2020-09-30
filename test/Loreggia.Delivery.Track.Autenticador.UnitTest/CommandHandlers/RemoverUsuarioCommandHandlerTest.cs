using Loreggia.Delivery.Track.Autenticador.Applications.EntityCommands.RemoverUsuario;
using Loreggia.Delivery.Track.Autenticador.BuilderTest.Commands;
using Loreggia.Delivery.Track.Autenticador.BuilderTest.Domain;
using Loreggia.Delivery.Track.Autenticador.Domain.Models;
using Loreggia.Delivery.Track.Autenticador.Domain.Repositories;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.CommandResults;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Interfaces;
using Loreggia.Delivery.Track.Autenticador.Shared.Domain.Notifications;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Loreggia.Delivery.Track.Autenticador.UnitTest.CommandHandlers
{
    public sealed class RemoverUsuarioCommandHandlerTest
    {
        private readonly IUsuarioRepository usuarioRepositoryMock;
        private readonly RemoverUsuarioCommandHandler handler;

        public RemoverUsuarioCommandHandlerTest()
        {
            usuarioRepositoryMock = Substitute.For<IUsuarioRepository>();

            var unitOfWorkMock = Substitute.For<IUnitOfWork>();
            unitOfWorkMock.CommitAsync().Returns(true);

            handler = new RemoverUsuarioCommandHandler(
                usuarioRepositoryMock,
                Substitute.For<ILogger<RemoverUsuarioCommand>>(),
                unitOfWorkMock,
                new NotificationContext(),
                Substitute.For<IMediatorHandler>());
        }

        [Fact]
        public async Task RemoverUsuarioCommandHandler_AoEditarUmUsuario_ENaoExiste_DeveRetorno_QueTemUmProblema()
        {
            var command = new RemoverUsuarioCommandBuilder().Builder();
            const string MESSAGE = "Usuário não encontrado";

            Usuario usuario = null;
            usuarioRepositoryMock.BuscarAsync(Arg.Any<Guid>()).Returns(usuario);

            var result = await handler.Handle(command, new CancellationToken()) as EntityCommandResult;

            Assert.True(result.HasAProblem);
            Assert.Equal(MESSAGE, result.Message);
        }

        [Fact]
        public async Task RemoverUsuarioCommandHandler_AoEditarUmUsuario_ComSucesso()
        {
            var command = new RemoverUsuarioCommandBuilder().Builder();


            Usuario usuario = new UsuarioBuilder().Builder();
            usuarioRepositoryMock.BuscarAsync(Arg.Any<Guid>()).Returns(usuario);

            var result = await handler.Handle(command, new CancellationToken()) as EntityCommandResult;

            Assert.True(result.Success);
        }
    }
}
