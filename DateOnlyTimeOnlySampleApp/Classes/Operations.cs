using DateOnlyTimeOnlySampleApp.Data;
using DateOnlyTimeOnlySampleApp.Models;
using static UtilityLibarary.SpectreConsoleHelpers;

namespace DateOnlyTimeOnlySampleApp.Classes;
internal class Operations
{
    public static async Task DateOnlyTimeOnlyTest()
    {
        await using var context = new Context();

        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        await context.Seed();

        RunningMessage("Database created and populated");

        var now = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
            DateTime.UtcNow, "UTC", "GMT");

        var today = DateOnly.FromDateTime(now);
        var currentTerms = await context.Schools
            .Include(s => s.Terms.Where(t => t.FirstDay <= today && t.LastDay >= today))
            .ToListAsync();


        foreach (var school in currentTerms)
        {
            var term = school.Terms.FirstOrDefault();
            if (term == null)
            {
                Console.WriteLine($"  {school.Name} is not current in term.");
            }
            else
            {
                Console.WriteLine($"  The current term for {school.Name} is '{term.Name}'.");
            }
        }

        var time = TimeOnly.FromDateTime(now);
        var dayOfWeek = today.DayOfWeek;
        List<School> openSchools;

        openSchools = await context.Schools
            .Where(
                s => s.Terms.Any(
                         t => t.FirstDay <= today
                              && t.LastDay >= today)
                     && s.OpeningHours[(int)dayOfWeek].OpensAt < time
                     && s.OpeningHours[(int)dayOfWeek].ClosesAt >= time)
            .ToListAsync();

        
        foreach (var school in openSchools)
        {
            Console.WriteLine($"  {school.Name} is open and closes at {school.OpeningHours.Single(e => e.DayOfWeek == dayOfWeek).ClosesAt}.");
        }
        

        context.ChangeTracker.Clear();

        foreach (var school in await context.Schools.Include(e => e.Terms).ToListAsync())
        {
            var winter = school.Terms.Single(e => e.LastDay.Year == 2022);
            winter.LastDay = winter.LastDay.AddDays(1);
            var friday = school.OpeningHours.Single(e => e.DayOfWeek == DayOfWeek.Friday);
            friday.OpensAt = friday.OpensAt?.AddHours(-1);
        }

        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();

        #region UpdateForSnowDay
        await context.Schools
            .Where(e => e.Terms.Any(t => t.LastDay.Year == 2022))
            .SelectMany(e => e.Terms)
            .ExecuteUpdateAsync(s => s.SetProperty(t => t.LastDay, t => t.LastDay.AddDays(1)));
        #endregion


        Console.WriteLine();
        RunningMessage("Done - see logs");
    }
}
