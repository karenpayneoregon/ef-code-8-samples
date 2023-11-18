using ComplexTypesSampleApp.Data;
using DefaultConstraintSampleApp.Models;
using static UtilityLibarary.SpectreConsoleHelpers;

namespace DefaultConstraintSampleApp.Classes;
internal class Operations
{
    public static async Task DefaultConstraintExample()
    {
        PrintCyan();

        await using var context = new Context();
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        RunningMessage("Database created");

        context.AddRange(
            new User(), 
            new User
            {
                Credits = 77
            }, new User
            {
                Credits = 0
            });

        await context.SaveChangesAsync();

        RunningMessage("Insert user property with int database default");

        RunningMessage("Insert user property with enum database default:");

        context.AddRange(
            new Course(), 
            new Course
            {
                Level = Level.Intermediate
            }, new Course
            {
                Level = Level.Beginner
            });

        await context.SaveChangesAsync();

        RunningMessage("Insert user property with bool database default:");

        context.AddRange(
            new Account(), 
            new Account
            {
                IsActive = true
            }, new Account
            {
                IsActive = false
            });

        await context.SaveChangesAsync();

        RunningMessage("Insert user property with int database default, sentinel configured:");

        context.AddRange(
            new UserWithSentinel(), 
            new UserWithSentinel
            {
                Credits = 77
            }, new UserWithSentinel
            {
                Credits = 0
            });

        await context.SaveChangesAsync();

        RunningMessage("Insert user property with enum database default, sentinel configured:");

        context.AddRange(new CourseWithSentinel(), 
            new CourseWithSentinel
            {
                Level = Level.Intermediate
            }, new CourseWithSentinel
            {
                Level = Level.Beginner
            });

        await context.SaveChangesAsync();

        RunningMessage("Insert user property with bool database default, sentinel configured:");

        context.AddRange(new AccountWithSentinel(), 
            new AccountWithSentinel
            {
                IsActive = true
            }, new AccountWithSentinel
            {
                IsActive = false
            });

        await context.SaveChangesAsync();

        RunningMessage("Insert user property with int database default, nullable backing field:");

        context.AddRange(new UserWithNullableBackingField(), 
            new UserWithNullableBackingField
            {
                Credits = 77
            }, new UserWithNullableBackingField
            {
                Credits = 0
            });

        await context.SaveChangesAsync();

        RunningMessage("Insert user property with enum database default, nullable backing field:");
        context.AddRange(new CourseWithNullableBackingField(), 
            new CourseWithNullableBackingField
            {
                Level = Level.Intermediate
            }, new CourseWithNullableBackingField
            {
                Level = Level.Beginner
            });

        await context.SaveChangesAsync();

        RunningMessage("Insert user property with bool database default, nullable backing field:");
        context.AddRange(new AccountWithNullableBackingField(), 
            new AccountWithNullableBackingField
            {
                IsActive = true
            }, new AccountWithNullableBackingField
            {
                IsActive = false
            });

        await context.SaveChangesAsync();

        RunningMessage("Done");
        Console.WriteLine();
    }
}
