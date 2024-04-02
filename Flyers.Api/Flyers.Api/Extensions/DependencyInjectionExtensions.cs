using Flyers.Api.EventBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Flyers.Api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, string connection)
        {
            if (string.IsNullOrEmpty(connection))
            {
                throw new ArgumentNullException();
            }
            services.AddSingleton<IEventBus>(new RabbitMQEventBus(connection));
            return services;
        }

        public static string GetMessageQueueConnectionString(this IConfiguration configuration, string name)
        {
            return configuration?.GetSection("MessageQueueConnectionString")?[name];
        }
    }
}