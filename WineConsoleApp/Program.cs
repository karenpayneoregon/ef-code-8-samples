using Spectre.Console;
using WineConsoleApp.Classes;
using WineConsoleApp.Data;

namespace WineConsoleApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        using var context = new WineContext();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        WineOperations.Run();

        Line();

        WineOperations.Indexing();

        Console.WriteLine();
        AnsiConsole.MarkupLine("[cyan]See log file under the app folder[/]");

        ExitPrompt();
    }
}