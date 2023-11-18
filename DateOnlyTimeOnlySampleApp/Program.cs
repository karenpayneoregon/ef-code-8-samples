
using DateOnlyTimeOnlySampleApp.Classes;
using static UtilityLibarary.SpectreConsoleHelpers;

namespace DateOnlyTimeOnlySampleApp;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Setup();
        await Operations.DateOnlyTimeOnlyTest();
        ExitPrompt();
    }
}