using System.Runtime.CompilerServices;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace NorthWind2020ConsoleApp;

partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample - EF Core NorthWind 2023 Reports to";
        AnsiConsole.MarkupLine("[cyan]Reading employee information[/]");
        W.SetConsoleWindowPosition(W.AnchorWindow.Center);
    }
}