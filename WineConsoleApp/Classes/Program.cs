using ConsoleHelperLibrary.Classes;
using Spectre.Console;
using System.Reflection;
using System.Runtime.CompilerServices;
// ReSharper disable CheckNamespace

namespace WineConsoleApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        var assembly = Assembly.GetEntryAssembly();
        var product = assembly?.GetCustomAttribute<AssemblyProductAttribute>()?.Product;

        Console.Title = product!;

        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);

        AnsiConsole.Write(
            new FigletText("EF Core Enum conversions: Wines")
                .Centered()
                .Color(Color.White));
    }
}
