
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Per.Order.Application;

public static class DependecyInyection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}
