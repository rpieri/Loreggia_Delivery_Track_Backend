using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Loreggia.Delivery.Track.Autenticador.Shared.API.Configurations
{
    public static class Cors
    {
        public const string POLICY_NAME = "cors_policy";

        public static void AddCorsAPI(this IServiceCollection services)
        {
            services.AddCors(config =>
            {
                config.AddPolicy(POLICY_NAME, policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("WWW-Authenticate", "www-authenticate");
                });
            });
        }
        public static void UseCorsAPI(this IApplicationBuilder app) => app.UseCors(POLICY_NAME);
    }
}