
using HierarchyIdSampleApp.Classes;
using static UtilityLibarary.SpectreConsoleHelpers;

namespace HierarchyIdSampleApp;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Setup();
        var test = DataConnections.Instance.MainConnection;
        await Operations.SQL_Server_HierarchyId();
        ExitPrompt();
    }
}