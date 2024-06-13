using ConsoleConfigurationLibrary.Classes;
using Microsoft.Extensions.DependencyInjection;
using SetPropertyValuesSample.Models;

namespace SetPropertyValuesSample.Classes;
internal class ApplicationConfiguration
{
    /// <summary>
    /// Sets up the services for connection string and should mock data be used
    /// </summary>
    /// <returns>ServiceCollection</returns>
    public static ServiceCollection ConfigureServices()
    {
        static void ConfigureService(IServiceCollection services)
        {

            services.Configure<ConnectionStrings>(Configuration.JsonRoot()
                .GetSection(nameof(ConnectionStrings)));

            services.Configure<EntityConfiguration>(Configuration.JsonRoot()
                .GetSection(nameof(EntityConfiguration)));
            
            services.AddTransient<SetupServices>();
        }

        var services = new ServiceCollection();
        ConfigureService(services);

        return services;

    }
}


