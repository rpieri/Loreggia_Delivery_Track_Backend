using Loreggia.Delivery.Track.Autenticador.Shared.Application.Behaviors;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Commands;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Handlers;
using Loreggia.Delivery.Track.Autenticador.Shared.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Loreggia.Delivery.Track.Autenticador.Shared.Application.DependencyInjection
{
    public static class ApplicationDependencyInjection
    {
        public static void AddApplicationnDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));
        }

        public static void AddApplicationMediatR<TCommand>(this IServiceCollection services) where TCommand : Command<TCommand> => services.AddMediatR(typeof(TCommand));
    }
}
