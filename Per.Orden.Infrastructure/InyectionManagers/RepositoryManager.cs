
using Microsoft.Extensions.DependencyInjection;
using Per.Order.Domain.Entities.OrderEntity.Repositories;
using Per.Order.Infrastructure.Persistence.Repositories;

namespace Per.Order.Infrastructure.InyectionManagers;

public static class RepositoryManager
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IOrderRepository, OrderRepository>();
        return services;
    }
}
