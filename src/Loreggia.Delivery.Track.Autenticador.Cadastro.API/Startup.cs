using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loreggia.Delivery.Track.Autenticador.Applications.EntityCommands.AdicionarUsuario;
using Loreggia.Delivery.Track.Autenticador.Cadastro.API.DependencyInjection;
using Loreggia.Delivery.Track.Autenticador.Cadastro.API.Services;
using Loreggia.Delivery.Track.Autenticador.DependencyInjection;
using Loreggia.Delivery.Track.Autenticador.Repository.Contexts;
using Loreggia.Delivery.Track.Autenticador.Shared.API.Configurations;
using Loreggia.Delivery.Track.Autenticador.Shared.API.DependencyInjection;
using Loreggia.Delivery.Track.Autenticador.Shared.API.Settings;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.DependencyInjection;
using Loreggia.Delivery.Track.Autenticador.Shared.Domain.DependecyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Loreggia.Delivery.Track.Autenticador.Cadastro.API
{
    public class Startup
    {
        private const int MAX_FILE_SIZE = 250 * 1024 * 1024; // 250MB;
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAPIDependencyInjection(configuration);
            services.AddDomainDependecyInjenction();
            services.AddApplicationnDependencyInjection();
            services.AddAutenticadorDependencyInjection(configuration);
            services.AddGRPCDependecyInjection();

            services.AddGrpc(opt =>
            {
                opt.MaxReceiveMessageSize = MAX_FILE_SIZE;
                opt.MaxSendMessageSize = MAX_FILE_SIZE;
            });

            services.AddSwaggerAPI();
            services.AddCorsAPI();
            services.AddVersionAPI();
            services.AddResponseCompressionAPI();
            services.AddApplicationMediatR<AdicionarUsuarioCommand>();
            services.AddLogAPI();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<ApiOptions> options, IApiVersionDescriptionProvider provider, EntityContext entityContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            entityContext.ExecuteMigrations();

            app.UseCorsAPI();
            app.UseSwaggerAPI(options, provider);
            app.UseResponseCompressionAPI();
            app.UseHttpsRedirectionAPI();
            app.UseStaticFileAPI();

            app.UseRoutingAPI();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GreeterService>();
                endpoints.MapGrpcService<UsuarioService>();
                endpoints.MapControllers();
            });
        }
    }
}
