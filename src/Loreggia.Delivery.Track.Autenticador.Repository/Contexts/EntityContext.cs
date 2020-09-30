using Loreggia.Delivery.Track.Autenticador.Domain.Models;
using Loreggia.Delivery.Track.Autenticador.Shared.EntityRepository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Loreggia.Delivery.Track.Autenticador.Repository.Contexts
{
    public sealed class EntityContext : Context<EntityContext>
    {
        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; private set; }
    }
}
