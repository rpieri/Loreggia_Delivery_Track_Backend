using Microsoft.AspNetCore.Builder;

namespace Loreggia.Delivery.Track.Autenticador.Shared.API.Configurations
{
    public static class HttpsRedirection
    {
        public static void UseHttpsRedirectionAPI(this IApplicationBuilder app) => app.UseHttpsRedirection();
    }
}
