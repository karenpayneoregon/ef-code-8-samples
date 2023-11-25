using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static UtilityLibarary.SpectreConsoleHelpers;

namespace Classes;
internal class Operations
{
    // 1. Initialize the database with some daily messages.
    public static async Task Initialize()
    {
        PrintCyan();
        using (var context = new DailyMessageContext())
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            context.AddRange(
                new DailyMessage { Message = "Remember: All builds are GA; no builds are RTM." },
                new DailyMessage { Message = "Keep calm and drink tea" });

            await context.SaveChangesAsync();
        }
    }

    public static async Task FirstSelectAsync()
    {
        PrintCyan();
        // 2. Query for the most recent daily message. It will be cached for 10 seconds.
        using (var context = new DailyMessageContext())
        {
            Console.WriteLine(await GetDailyMessage(context));
        }
    }

    public static async Task InsertRecordAsync()
    {
        PrintCyan();
        using var context = new DailyMessageContext();
        context.Add(new DailyMessage { Message = "Free beer for unicorns" });

        await context.SaveChangesAsync();
    }

    // Cached message is used until cache expires.
    public static async Task CachedMessageAsync()
    {
        using var context = new DailyMessageContext();
        Console.WriteLine(await GetDailyMessage(context));
        //Pretend it's the next day.
        Thread.Sleep(10000);
    }

    public static async Task CacheIsExpiredAsync()
    {
        PrintCyan();
        using var context = new DailyMessageContext();
        Console.WriteLine(await GetDailyMessage(context));
    }

    public static async Task<string> GetDailyMessage(DailyMessageContext context)
    {
        var message = await context.DailyMessages.TagWith("Get_Daily_Message").OrderBy(e => e.Id).LastAsync();
        return message.Message;
    }
}
