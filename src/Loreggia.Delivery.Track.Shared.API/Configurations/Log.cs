using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Loreggia.Delivery.Track.Autenticador.Shared.API.Configurations
{
    public static class Log
    {
        public static void AddLogAPI(this IServiceCollection services)
            => services.AddLogging(opt =>
            {
                opt.AddFilter("Grpc", LogLevel.Debug);
                opt.AddConsole(c => c.TimestampFormat = "[yyy-MM-dd HH:mm:ss]");
            });
    }
}
