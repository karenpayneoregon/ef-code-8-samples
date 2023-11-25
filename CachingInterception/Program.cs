using System.Threading.Tasks;
using Classes;
using Spectre.Console;
using static UtilityLibarary.SpectreConsoleHelpers;

// ReSharper disable once CheckNamespace
namespace CachingInterception;

public partial class Program
{
    private static async Task Main()
    {
        
        Message("See LogFiles\\ef-logs.txt when done");

        await Operations.Initialize();
        await Operations.FirstSelectAsync();
        await Operations.InsertRecordAsync();
        await Operations.CachedMessageAsync();
        await Operations.CacheIsExpiredAsync();

        ExitPrompt();
    }
}
