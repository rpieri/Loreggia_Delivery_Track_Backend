using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Loreggia.Delivery.Track.Autenticador.Shared.API.Configurations
{
    public static class ResponseCompression
    {
        public static void AddResponseCompressionAPI(this IServiceCollection services) => services.AddResponseCompression();

        public static void UseResponseCompressionAPI(this IApplicationBuilder app) => app.UseResponseCompression();
    }
}
