using Loreggia.Delivery.Track.Autenticador.Shared.Domain.Models;
using Loreggia.Delivery.Track.Autenticador.Shared.EntityRepository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Loreggia.Delivery.Track.Autenticador.Shared.EntityRepository.Repositories
{
    public abstract class EntityRepository<TEntity, TContext> where TEntity : Entity where TContext : Context<TContext>
    {
        protected readonly DbSet<TEntity> dbSet;

        public EntityRepository(TContext context) => dbSet = context.Set<TEntity>();
    }
}
