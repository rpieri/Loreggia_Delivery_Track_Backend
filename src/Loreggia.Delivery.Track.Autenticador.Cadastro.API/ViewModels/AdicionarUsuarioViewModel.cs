using Loreggia.Delivery.Track.Autenticador.Applications.EntityCommands.AdicionarUsuario;
using Loreggia.Delivery.Track.Autenticador.Shared.ViewModels;

namespace Loreggia.Delivery.Track.Autenticador.Cadastro.API.ViewModels
{
    public class AdicionarUsuarioViewModel : ViewModelToCommand<AdicionarUsuarioCommand>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public override AdicionarUsuarioCommand Mapping() => new AdicionarUsuarioCommand(null, Nome, Email, Senha);
    }
}
