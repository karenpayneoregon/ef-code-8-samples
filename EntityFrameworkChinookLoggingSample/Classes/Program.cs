using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace EntityFrameworkChinookLoggingSample;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "EF Core log to file Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
