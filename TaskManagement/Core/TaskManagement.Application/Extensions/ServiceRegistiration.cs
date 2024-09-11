using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Extensions
{
    public static class ServiceRegistiration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(LoginRequest));

        }
    }
}
