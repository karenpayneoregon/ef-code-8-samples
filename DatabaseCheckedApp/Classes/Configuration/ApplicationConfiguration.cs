using DatabaseCheckedApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseCheckedApp.Classes.Configuration;

internal class ApplicationConfiguration
{
    /// <summary>
    /// Read sections from appsettings.json
    /// </summary>
    public static IConfigurationRoot ConfigurationRoot() =>
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

    public static ServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();
        ConfigureService(services);

        return services;

        static void ConfigureService(IServiceCollection services)
        {

            services.Configure<ConnectionStrings>(ConfigurationRoot()
                .GetSection(nameof(ConnectionStrings)));

            services.AddTransient<SetupServices>();
        }
    }

    /// <summary>
    /// Retrieves the names of database tables as specified in the "DatabaseTables" section of the configuration file.
    /// </summary>
    /// <returns>
    /// An array of strings containing the names of the database table names.
    /// </returns>
    public static string[] GetTableNames()
    {
        var sec = ConfigurationRoot().GetSection("DatabaseTables");
        return [sec["Customer"], sec["ContactTypes"], sec["Genders"]];
    }
}


