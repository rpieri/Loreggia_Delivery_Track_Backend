using Loreggia.Delivery.Track.Autenticador.Shared.Application.Commands;

namespace Loreggia.Delivery.Track.Autenticador.Shared.ViewModels
{
    public abstract class ViewModelToCommand<TCommand> where TCommand : Command<TCommand>
    {
        public abstract TCommand Mapping();
    }
}
