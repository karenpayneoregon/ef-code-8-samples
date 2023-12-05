using System.Runtime.CompilerServices;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace NorthWind2020ConsoleApp;

partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        string PathJoin(string text1, string text2, string text3, string separator = "/") 
            => $"{text1}{separator}{text2}{separator}{text3}";

        Console.Title = PathJoin("Code sample", "EF Core NorthWind 2023", "2023 Reports to");
        AnsiConsole.MarkupLine("[cyan]Reading employee information[/]");

        W.SetConsoleWindowPosition(W.AnchorWindow.Center);

    }
}