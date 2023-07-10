using HRManagement.Application.Contracts.Persistance;
using HRManagement.Persistance.DatabaseContext;
using HRManagement.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        public static IServiceCollection AddPeristanceServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HrDatabaseContext> (options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HrDatabaseConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepositor<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

            return services;

        }
    }
}
