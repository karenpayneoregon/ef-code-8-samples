using WineConsoleApp.Classes;
using WineConsoleApp.Data;
using static WineConsoleApp.Classes.AnsiConsoleHelpers;

namespace WineConsoleApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        var image = Properties.Resources.wine;
        using var context = new WineContext();

        context.CleanStart();

        WineOperations.Run();
        
        Line();

        WineOperations.Indexing();

        Console.WriteLine();
        CyanMarkup("[cyan]See ef core log file under the app folder[/]");

        ExitPrompt();
    }

}