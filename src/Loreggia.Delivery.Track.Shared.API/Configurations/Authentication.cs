using Loreggia.Delivery.Track.Autenticador.Shared.API.Settings;
using Loreggia.Delivery.Track.Autenticador.Shared.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Loreggia.Delivery.Track.Autenticador.Shared.API.Configurations
{
    public static class Authentication
    {
        public static void AddAuthenticationAPI(this IServiceCollection services)
        {
            var setting = SettingsOperations.GetConfiguration<AuthenticationOptions>(services);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = setting.Authority;
                    options.Audience = setting.Audience;
                    options.RequireHttpsMetadata = false;
                });
        }

        public static void UseAuthenticationAPI(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
