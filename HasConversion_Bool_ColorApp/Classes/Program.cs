using ConsoleConfigurationLibrary.Classes;
using HasConversion_Bool_ColorApp.Classes.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;
using static ConsoleConfigurationLibrary.Classes.ApplicationConfiguration;

// ReSharper disable once CheckNamespace
namespace HasConversion_Bool_ColorApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        var assembly = Assembly.GetEntryAssembly();
        var product = assembly?.GetCustomAttribute<AssemblyProductAttribute>()?.Product;

        Console.Title = product!;

        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);

        SetupLogging.Development();
        Setup();
    }

    /// <summary>
    /// Configures and initializes the application's services and settings.
    /// </summary>
    /// <remarks>
    /// This method sets up dependency injection, retrieves connection strings, 
    /// applies entity settings, and configures the console's encoding.
    /// It is a core part of the application's initialization process.
    /// </remarks>
    private static void Setup()
    {
        var services = ConfigureServices();
        using var provider = services.BuildServiceProvider();
        var setup = provider.GetService<SetupServices>();
        setup.GetConnectionStrings();
        setup.GetEntitySettings();
        SpectreConsoleHelpers.SetEncoding();
    }
    /// <summary>
    /// Creates and configures a table for displaying information about people.
    /// </summary>
    /// <returns>
    /// A <see cref="Table"/> instance with predefined columns, borders, alignment, and title.
    /// </returns>
    /// <remarks>
    /// The table includes columns for Id, First Name, Last Name, string representation of a boolean value,
    /// boolean value, color, and birth date. It is styled with a rounded border, a light slate grey border color,
    /// and a centered title.
    /// </remarks>
    private static Table CreateTable()
    {
        return new Table()
            .RoundedBorder().BorderColor(Color.LightSlateGrey)
            .AddColumn("[b]Id[/]")
            .AddColumn("[b]First[/]")
            .AddColumn("[b]Last[/]")
            .AddColumn("[b]Is-string[/]")
            .AddColumn("[b]Is-bool[/]")
            .AddColumn("[b]Color[/]")
            .AddColumn("[b]Born[/]")
            .Alignment(Justify.Center)
            .Title("[white on blue]Friends[/]");
    }
}
