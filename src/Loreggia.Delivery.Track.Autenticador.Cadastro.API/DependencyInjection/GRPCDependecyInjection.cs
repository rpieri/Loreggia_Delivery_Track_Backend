using Loreggia.Delivery.Track.Autenticador.Cadastro.API.MapperProto;
using Microsoft.Extensions.DependencyInjection;

namespace Loreggia.Delivery.Track.Autenticador.Cadastro.API.DependencyInjection
{
    public static class GRPCDependecyInjection
    {
        public static void AddGRPCDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<AdicionarUsuarioCommandMapping>();
            services.AddScoped<UsuarioCommandResultMapping>();
        }
    }
}
