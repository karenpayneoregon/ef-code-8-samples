using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using DatabaseCheckedApp.Classes.Configuration;

// ReSharper disable once CheckNamespace
namespace DatabaseCheckedApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

    /// <summary>
    /// Configures and initializes the application's services and dependencies.
    /// </summary>
    /// <remarks>
    /// This method sets up the dependency injection container by configuring services
    /// through <see cref="ApplicationConfiguration.ConfigureServices"/> and retrieves
    /// connection strings using <see cref="SetupServices.GetConnectionStrings"/>.
    /// </remarks>
    private static async Task Setup()
    {
        var services = ApplicationConfiguration.ConfigureServices();
        await using var serviceProvider = services.BuildServiceProvider();
        serviceProvider.GetService<SetupServices>()!.GetConnectionStrings();
    }
}
