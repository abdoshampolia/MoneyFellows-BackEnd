using Microsoft.Extensions.DependencyInjection;
using MoneyFellows.Application.Contracts.Repository;
using MoneyFellows.Infrastructure.Repository;

namespace MoneyFellows.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        //RepositoryRegistration
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepoistory>();
            return services;
        }
    }
}
