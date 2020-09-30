namespace Loreggia.Delivery.Track.Autenticador.Shared.Application.Commands
{
    public abstract class QueryCommand<TQueryCommand> : Command<TQueryCommand> where TQueryCommand : Command<TQueryCommand>
    {
    }
}
