using Microsoft.AspNetCore.Builder;

namespace Loreggia.Delivery.Track.Autenticador.Shared.API.Configurations
{
    public static class Routing
    {
        public static void UseRoutingAPI(this IApplicationBuilder app)
            => app.UseRouting();
    }
}
