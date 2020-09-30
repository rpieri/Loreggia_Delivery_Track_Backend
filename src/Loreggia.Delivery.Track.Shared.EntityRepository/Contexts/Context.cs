using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Loreggia.Delivery.Track.Autenticador.Shared.EntityRepository.Contexts
{
    public abstract class Context<TContext> : DbContext where TContext : Context<TContext>
    {
        public Context(DbContextOptions<TContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public void ExecuteMigrations() => Database.Migrate();
    }
}
