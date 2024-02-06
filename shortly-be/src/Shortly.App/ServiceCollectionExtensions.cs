using Microsoft.Extensions.DependencyInjection;

namespace Shortly.App;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}