using WineConsoleApp.Classes;
using WineConsoleApp.Data;
using static WineConsoleApp.Classes.AnsiConsoleHelpers;

namespace WineConsoleApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        Startup.Clean();

        var wines = WineOperations.GetAllWines();



        CyanMarkup("[cyan]See ef core log file under the app folder[/]");

        ExitPrompt();
    }

}