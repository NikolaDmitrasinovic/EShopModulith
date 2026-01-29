using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Carter;

namespace Shared.Extentions;
public static class Extentions
{
    public static IServiceCollection AddCarterWithAsseblies
        (this IServiceCollection services, params Assembly[] asseblies)
    {
        services.AddCarter(configurator: config =>
        {
            foreach (var assembly in asseblies)
            {
                var modules = assembly.GetTypes()
                .Where(t => t.IsAssignableTo(typeof(ICarterModule))).ToArray();

                config.WithModules(modules);
            }
        });

        return services;
    }
}
