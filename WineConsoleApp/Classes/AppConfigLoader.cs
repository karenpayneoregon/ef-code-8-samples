using Microsoft.Extensions.Configuration;
using WineConsoleApp.Models;

namespace WineConsoleApp.Classes;
internal class AppConfigLoader
{
    public static ApplicationSettings LoadSettings()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory) // ensures it works regardless of platform
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        IConfiguration configuration = builder.Build();

        var settings = new ApplicationSettings();
        configuration.GetSection("ApplicationSettings").Bind(settings);

        return settings;
    }
}
