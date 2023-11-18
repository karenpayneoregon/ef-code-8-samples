
using ExecuteUpdateDeleteSampleApp.Classes;
using static UtilityLibarary.SpectreConsoleHelpers;

namespace ExecuteUpdateDeleteSampleApp;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Setup();
        await Operations.ExecuteUpdateDeleteSample();
        ExitPrompt();
    }
}