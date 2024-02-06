using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Shortly.Database;

public static class Progam
{
    public static void Main(string[] args)
    {
        using var host = CreateHost(args);

        var migrationService = host.Services.GetRequiredService<MigrationService>();

        Console.WriteLine("Running migrations...");

        migrationService.Run();

        Console.WriteLine("Migrations finished!");
    }

    private static IHost CreateHost(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .UseConsoleLifetime()
            .ConfigureServices((builder, services) =>
            {
                services
                    .AddScoped<MigrationService>(_ =>
                        new MigrationService(builder.Configuration.GetConnectionString("shortly")!));
            })
            .Build();
    }
}