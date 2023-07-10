using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPeristanceServices (this IServiceCollection services)
        {
            return services;
        }
    }
}
