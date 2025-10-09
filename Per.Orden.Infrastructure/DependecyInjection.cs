
using Microsoft.Extensions.DependencyInjection;
using Per.Order.Infrastructure.InyectionManagers;

namespace Per.Order.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
    {
        RepositoryManager.AddRepositories(services);
        return services;
    }
}
