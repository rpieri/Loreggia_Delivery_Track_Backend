using Loreggia.Delivery.Track.Autenticador.Domain.Repositories;
using Loreggia.Delivery.Track.Autenticador.ReadOnlyRepository.Contexts;
using Loreggia.Delivery.Track.Autenticador.ReadOnlyRepository.Repositories;
using Loreggia.Delivery.Track.Autenticador.Repository.Contexts;
using Loreggia.Delivery.Track.Autenticador.Repository.Repositories;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Interfaces;
using Loreggia.Delivery.Track.Autenticador.Shared.EntityRepository.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Loreggia.Delivery.Track.Autenticador.DependencyInjection
{
    public static class AutenticadorDependencyInjection
    {
        public static void AddAutenticadorDependencyInjection(this IServiceCollection services, IConfiguration configuration, bool isTesting = false)
        {
            services.AddDbContext<EntityContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("Default"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork<EntityContext>>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<DapperContext>();
            services.AddScoped<IUsuarioReadOnlyRepository, UsuarioReadOnlyRepository>();
        }
    }
}
