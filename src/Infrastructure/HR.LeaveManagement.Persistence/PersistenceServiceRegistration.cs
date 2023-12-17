using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Persistence
{
    public class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HrDatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("HrDatabaseConnectionString")));
            return services;
        }
    }
}