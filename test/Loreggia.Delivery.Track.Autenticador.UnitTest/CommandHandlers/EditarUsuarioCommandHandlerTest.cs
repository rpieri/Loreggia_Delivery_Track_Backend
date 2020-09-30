using Loreggia.Delivery.Track.Autenticador.Applications.EntityCommands.EditarUsuario;
using Loreggia.Delivery.Track.Autenticador.BuilderTest.Commands;
using Loreggia.Delivery.Track.Autenticador.BuilderTest.Domain;
using Loreggia.Delivery.Track.Autenticador.Domain.Models;
using Loreggia.Delivery.Track.Autenticador.Domain.Repositories;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.CommandResults;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Interfaces;
using Loreggia.Delivery.Track.Autenticador.Shared.Domain.Notifications;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NSubstitute;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Loreggia.Delivery.Track.Autenticador.UnitTest.CommandHandlers
{
    public sealed class EditarUsuarioCommandHandlerTest
    {
        private readonly IUsuarioRepository usuarioRepositoryMock;
        private readonly EditarUsuarioCommandHandler handler;

        public EditarUsuarioCommandHandlerTest()
        {
            usuarioRepositoryMock = Substitute.For<IUsuarioRepository>();

            var unitOfWorkMock = Substitute.For<IUnitOfWork>();
            unitOfWorkMock.CommitAsync().Returns(true);

            handler = new EditarUsuarioCommandHandler(
                usuarioRepositoryMock,
                Substitute.For<ILogger<EditarUsuarioCommand>>(),
                unitOfWorkMock,
                new NotificationContext(),
                Substitute.For<IMediatorHandler>());
        }

        [Fact]
        public async Task EditarUsuarioCommandHandler_AoEditarUmUsuario_ENaoExiste_DeveRetorno_QueTemUmProblema()
        {
            var command = new EditarUsuarioCommandBuilder().Builder();
            const string MESSAGE = "Usuário não foi encontrado";

            Usuario usuario = null;
            usuarioRepositoryMock.BuscarAsync(Arg.Any<Guid>()).Returns(usuario);

            var result = await handler.Handle(command, new CancellationToken()) as EntityCommandResult;

            Assert.True(result.HasAProblem);
            Assert.Equal(MESSAGE, result.Message);
        }

        [Fact]
        public async Task EditarUsuarioCommandHandler_AoEditarUmUsuario_EMailFoiAlterado_EJaFoiCadastrado_DeveRetorno_QueTemUmProblema()
        {

            var email = "res@res.com";
            var message = $"E-mail: {email} já esta cadastrado no sistema";

            var command = new EditarUsuarioCommandBuilder().ComEmail(email).Builder();
            

            Usuario usuario = new UsuarioBuilder().Builder();
            usuarioRepositoryMock.BuscarAsync(Arg.Any<Guid>()).Returns(usuario);
            usuarioRepositoryMock.EmailJaCadastradoAsync(Arg.Any<string>()).Returns(true);

            var result = await handler.Handle(command, new CancellationToken()) as EntityCommandResult;

            Assert.True(result.HasAProblem);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async Task EditarUsuarioCommandHandler_AoEditarUmUsuario_ComSucesso()
        {
            var command = new EditarUsuarioCommandBuilder().Builder();


            Usuario usuario = new UsuarioBuilder().Builder();
            usuarioRepositoryMock.BuscarAsync(Arg.Any<Guid>()).Returns(usuario);
            usuarioRepositoryMock.EmailJaCadastradoAsync(Arg.Any<string>()).Returns(false);

            var result = await handler.Handle(command, new CancellationToken()) as EntityCommandResult;

            Assert.True(result.Success);
        }
    }
}
