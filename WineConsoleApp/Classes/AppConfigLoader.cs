using Microsoft.Extensions.Configuration;
using WineConsoleApp.Models;

namespace WineConsoleApp.Classes;

/// <summary>
/// Provides functionality to load application configuration settings from a JSON file.
/// </summary>
/// <remarks>
/// This class is responsible for reading the "appsettings.json" file, binding its content to the 
/// <see cref="WineConsoleApp.Models.ApplicationSettings"/> object, and returning the populated settings.
/// </remarks>
internal class AppConfigLoader
{
    /// <summary>
    /// Loads application settings from the "appsettings.json" file.
    /// </summary>
    /// <returns>
    /// An instance of <see cref="ApplicationSettings"/> populated with the configuration values.
    /// </returns>
    /// <remarks>
    /// This method reads the "appsettings.json" file located in the application's base directory, 
    /// binds the "ApplicationSettings" section to an <see cref="ApplicationSettings"/> object, 
    /// and returns the populated object. The file must exist and be properly formatted.
    /// </remarks>
    public static ApplicationSettings LoadSettings()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory) 
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        IConfiguration configuration = builder.Build();

        var settings = new ApplicationSettings();
        configuration.GetSection(nameof(ApplicationSettings)).Bind(settings);

        return settings;
    }
}
