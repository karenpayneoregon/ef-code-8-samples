using System.Runtime.CompilerServices;
using ConsoleHelperLibrary.Classes;

// ReSharper disable once CheckNamespace
namespace DualContextsApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
