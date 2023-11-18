
using DefaultConstraintSampleApp.Classes;
using static UtilityLibarary.SpectreConsoleHelpers;

namespace DefaultConstraintSampleApp;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Setup();
        await Operations.DefaultConstraintExample();
        ExitPrompt();
    }
}