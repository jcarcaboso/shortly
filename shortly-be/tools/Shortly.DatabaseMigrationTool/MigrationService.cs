using System;
using System.Data.Common;
using System.Reflection;
using System.Text;
using DbUp;

namespace Shortly.Database;

public sealed class MigrationService(string connection)
{
    public void Run()
    {
        try
        {
            EnsureDatabase.For.PostgresqlDatabase(connection);
            var scripts = Assembly.GetExecutingAssembly();
            var upgradeEngine = DeployChanges.To
                .PostgresqlDatabase(connection)
                .WithScriptsEmbeddedInAssembly(
                    Assembly.GetExecutingAssembly(),
                    s => s.Contains(".Scripts."),
                    Encoding.UTF8)
                .LogToConsole()
                .Build();

            var result = upgradeEngine.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failure!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success!");
            }
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Failure!");
            Console.WriteLine(e);
        }

        Console.ResetColor();
    }
}