using Loreggia.Delivery.Track.Autenticador.Shared.GRPCClient.Facades;
using Microsoft.Extensions.DependencyInjection;

namespace Loreggia.Delivery.Track.Autenticador.Shared.GRPCClient.DependencyInjection
{
    public static class GRPCDependencyInjection
    {
        public static void AddGRPCDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ClientFacade>();
        }
    }
}
