using Loreggia.Delivery.Track.Autenticador.Shared.API.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Loreggia.Delivery.Track.Autenticador.Shared.API.DependencyInjection
{
    public static class APIDependencyInjection
    {
        public static void AddAPIDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiOptions>(configuration.GetSection("API"));
            services.Configure<AuthenticationOptions>(configuration.GetSection("AUTHENTICATION"));
        }
    }
}
