using Arquitectura.Domain.Interfaces.Repositories;
using Arquitectura.Infraestructura.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.Infraestructura
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddScoped<IDbServices, DbServices>();
            services.AddScoped<IEmployeeServices, EmployeeService>();

            return services;
        }
    }
}
