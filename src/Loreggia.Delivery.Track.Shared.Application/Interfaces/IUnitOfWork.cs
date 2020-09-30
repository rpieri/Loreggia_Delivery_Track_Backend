using System;
using System.Threading.Tasks;

namespace Loreggia.Delivery.Track.Autenticador.Shared.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
    }
}
