using Flyers.Api.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyers.Api.Configurations
{
    public static class EventBusConfiguration
    {
        //public static void AddEventBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddEventBus(configuration
        //        .GetMessageQueueConnectionString("DefaultConnection"));
        //}

        public static IServiceCollection AddEventBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddEventBus(configuration
                .GetMessageQueueConnectionString("DefaultConnection"));
        }
    }
}
