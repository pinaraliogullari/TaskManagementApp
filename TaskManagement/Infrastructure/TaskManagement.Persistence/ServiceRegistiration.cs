using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Interfaces;
using TaskManagement.Persistence.Context;
using TaskManagement.Persistence.Repositories;

namespace TaskManagement.Persistence
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPriorityRepository, PriorityRepository>();
        }
    }
}
