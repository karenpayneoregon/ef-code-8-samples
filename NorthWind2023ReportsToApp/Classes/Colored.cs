using System.Runtime.CompilerServices;

namespace NorthWind2023ReportsToApp.Classes;

public class Colored
{
    [ModuleInitializer]
    public static void InitColored()
    {
        AnsiConsole.MarkupLine("[cyan]Reading employee information[/]");
    }
}