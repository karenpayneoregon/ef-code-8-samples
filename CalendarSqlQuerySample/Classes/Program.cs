using CalendarSqlQuerySample.Classes.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace CalendarSqlQuerySample;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
    private static async Task Setup()
    {
        var services = ApplicationConfiguration.ConfigureServices();
        await using var serviceProvider = services.BuildServiceProvider();
        serviceProvider.GetService<SetupServices>()!.GetConnectionStrings();
    }
}
