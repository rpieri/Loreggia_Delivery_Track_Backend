using Microsoft.AspNetCore.Builder;

namespace Loreggia.Delivery.Track.Autenticador.Shared.API.Configurations
{
    public static class StaticFile
    {
        public static void UseStaticFileAPI(this IApplicationBuilder app)
            => app.UseStaticFiles();
    }
}
