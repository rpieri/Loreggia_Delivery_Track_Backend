using Loreggia.Delivery.Track.Autenticador.Shared.Domain.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace Loreggia.Delivery.Track.Autenticador.Shared.Domain.DependecyInjection
{
    public static class DomainDependencyInjection
    {
        public static void AddDomainDependecyInjenction(this IServiceCollection services)
        {
            services.AddScoped<NotificationContext>();
        }
    }
}
