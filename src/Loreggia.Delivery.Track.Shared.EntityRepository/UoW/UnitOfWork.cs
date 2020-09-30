using Loreggia.Delivery.Track.Autenticador.Shared.Application.Interfaces;
using Loreggia.Delivery.Track.Autenticador.Shared.EntityRepository.Contexts;
using System.Threading.Tasks;

namespace Loreggia.Delivery.Track.Autenticador.Shared.EntityRepository.UoW
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : Context<TContext>
    {
        private readonly TContext context;

        public UnitOfWork(TContext context) => this.context = context;
        public async Task<bool> CommitAsync() => await context.SaveChangesAsync() > 0;

        public async void Dispose() => await context.DisposeAsync();
    }
}
