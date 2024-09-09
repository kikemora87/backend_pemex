using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.Aplication
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            /*services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(DependencyContainer).Assembly));*/

            return services;
        }
    }
}
