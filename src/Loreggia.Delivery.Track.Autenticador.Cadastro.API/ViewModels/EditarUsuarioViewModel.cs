using Loreggia.Delivery.Track.Autenticador.Applications.EntityCommands.EditarUsuario;
using Loreggia.Delivery.Track.Autenticador.Shared.ViewModels;
using System;

namespace Loreggia.Delivery.Track.Autenticador.Cadastro.API.ViewModels
{
    public class EditarUsuarioViewModel : ViewModelToCommand<EditarUsuarioCommand>
    {
        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public override EditarUsuarioCommand Mapping() => new EditarUsuarioCommand(Codigo, Nome, Email, Senha);
    }
}
