using System.Reflection;
using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Play.Common.Settings;

namespace Play.Common.MassTransit
{
    public static class Extensions 
    {
        public static IServiceCollection AddMassTransitWithRabbitMQ(this IServiceCollection services) 
        {
             services.AddMassTransit(configure => 
            {
                configure.AddConsumers(Assembly.GetEntryAssembly());

                configure.UsingRabbitMq((context, configutator) => 
                {
                     var configuration = context.GetService<IConfiguration>();
                var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
                    var rabbitMQSettings = configuration.GetSection(nameof(RabbitMQSettings)).Get<RabbitMQSettings>();
                    configutator.Host(rabbitMQSettings.Host);
                    configutator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(serviceSettings.ServiceName, false));
                });
            });

            // Start RabbitMQ Bus
            services.AddMassTransitHostedService();

            return services;
        }
    }
}