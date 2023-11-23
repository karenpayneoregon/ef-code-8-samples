using ConsoleHelperLibrary.Classes;
using Spectre.Console;
using System.Runtime.CompilerServices;
// ReSharper disable CheckNamespace

namespace WineConsoleApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample: EF Core conversions";
        
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Fill);

        AnsiConsole.Write(
            new FigletText("EF Core Enum conversions: Wines")
                .Centered()
                .Color(Color.White));
    }
}
