using Domain.Endpoint.Interfaces.Repositories;
using Infrastructure.Endpoint.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Endpoint.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IToDosRepository, ToDosRepository>();
            return services;
        }
    }
}
