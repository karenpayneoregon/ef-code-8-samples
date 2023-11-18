
using ComplexTypesSampleApp.Classes;
using static UtilityLibarary.SpectreConsoleHelpers;

namespace ComplexTypesSampleApp;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Setup();
        await Operations.ComplexTypesDemo();
        AnsiConsole.MarkupLine("[yellow]Done, see log file[/]");
        ExitPrompt();
    }
}