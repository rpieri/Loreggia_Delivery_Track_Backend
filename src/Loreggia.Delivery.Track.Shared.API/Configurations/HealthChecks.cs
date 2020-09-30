using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Loreggia.Delivery.Track.Autenticador.Shared.API.Configurations
{
    public static class HealthChecks
    {
        public static void AddHealthChecksAPI(this IServiceCollection services)
            => services.AddHealthChecks();

        public static void UseHealthChecksAPI(this IApplicationBuilder api)
            => api.UseHealthChecks("/health");
    }
}
