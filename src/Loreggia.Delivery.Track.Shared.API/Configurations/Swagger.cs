using Loreggia.Delivery.Track.Autenticador.Shared.API.Settings;
using Loreggia.Delivery.Track.Autenticador.Shared.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Collections.Generic;

namespace Loreggia.Delivery.Track.Autenticador.Shared.API.Configurations
{
    public static class Swagger
    {
        public static void AddSwaggerAPI(this IServiceCollection services)
        {
            var setting = SettingsOperations.GetConfiguration<ApiOptions>(services);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(setting.Version, new OpenApiInfo
                {
                    Title = setting.Title,
                    Description = setting.Description,
                    Contact = new OpenApiContact
                    {
                        Email = setting.SupportEmail,
                        Name = setting.SupportName
                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header
                            },
                            new List<string>()
                        }
                });
            });
        }

        public static void UseSwaggerAPI(this IApplicationBuilder app, IOptions<ApiOptions> options, IApiVersionDescriptionProvider provider)
        {
            var setting = options.Value;
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    c.DocExpansion(DocExpansion.List);
                }
            });
        }
    }
}
