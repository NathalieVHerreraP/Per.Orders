using Microsoft.AspNetCore.Builder;

namespace Per.Order.Presentation.Modules;

public class ModulesConfiguration
{
    public static void Configure(WebApplication app)
    {
        app.AddOrderModules();
    }
}
