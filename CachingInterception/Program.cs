using System.Threading.Tasks;
using Classes;
using static UtilityLibarary.SpectreConsoleHelpers;

namespace CachingInterception;

public partial class Program
{
    private static async Task Main()
    {
        await Operations.Initialize();
        await Operations.FirstSelectAsync();
        await Operations.InsertRecordAsync();
        await Operations.CachedMessageAsync();
        await Operations.CacheIsExpiredAsync();
        ExitPrompt();
    }
}
