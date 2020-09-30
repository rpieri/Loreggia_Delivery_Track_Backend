using Microsoft.AspNetCore.Builder;

namespace Loreggia.Delivery.Track.Autenticador.Shared.API.Configurations
{
    public static class Endpoint
    {
        public static void UseEndPointsAPI(this IApplicationBuilder app)
            => app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
