using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shortly.Infrastructure.Models;

namespace Shortly.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDbContext<ShortlyContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("DB"));
            })
            .AddScoped<IMappingRepository, MappingRepository>();

        return services;
    }
}