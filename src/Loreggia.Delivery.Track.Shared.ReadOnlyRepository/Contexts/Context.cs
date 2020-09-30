using System.Data;

namespace Loreggia.Delivery.Track.Autenticador.Shared.ReadOnlyRepository.Contexts
{
    public abstract class Context
    {
        public abstract IDbConnection CreateConnection();
    }
}
