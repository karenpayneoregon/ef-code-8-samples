
using DateOnlyTimeOnlySampleApp.Models;

// ReSharper disable once CheckNamespace
namespace DateOnlyTimeOnlySampleApp.Data;
internal partial class Context
{
    public async Task Seed()
    {
        AddRange(
            new School
            {
                Name = "Stowe School",
                Founded = new(1923, 5, 11),
                Terms =
                {
                    new() { Name = "Michaelmas", FirstDay = new(2022, 9, 7), LastDay = new(2022, 12, 16) },
                    new() { Name = "Lent", FirstDay = new(2023, 1, 8), LastDay = new(2023, 3, 24) },
                    new() { Name = "Summer", FirstDay = new(2023, 4, 18), LastDay = new(2023, 7, 8) }
                },
                OpeningHours =
                {
                    new(DayOfWeek.Sunday, null, null),
                    new(DayOfWeek.Monday, new(8, 00), new(18, 00)),
                    new(DayOfWeek.Tuesday, new(8, 00), new(18, 00)),
                    new(DayOfWeek.Wednesday, new(8, 00), new(18, 00)),
                    new(DayOfWeek.Thursday, new(8, 00), new(18, 00)),
                    new(DayOfWeek.Friday, new(8, 00), new(18, 00)),
                    new(DayOfWeek.Saturday, new(8, 00), new(17, 00))
                }
            },
            new School
            {
                Name = "Farr High School",
                Founded = new(1964, 5, 1),
                Terms =
                {
                    new() { Name = "Autumn", FirstDay = new(2022, 8, 16), LastDay = new(2022, 12, 23) },
                    new() { Name = "Winter", FirstDay = new(2023, 1, 9), LastDay = new(2023, 3, 31) },
                    new() { Name = "Summer", FirstDay = new(2023, 4, 17), LastDay = new(2023, 6, 29) }
                },
                OpeningHours =
                {
                    new(DayOfWeek.Sunday, null, null),
                    new(DayOfWeek.Monday, new(8, 45), new(15, 35)),
                    new(DayOfWeek.Tuesday, new(8, 45), new(15, 35)),
                    new(DayOfWeek.Wednesday, new(8, 45), new(15, 35)),
                    new(DayOfWeek.Thursday, new(8, 45), new(15, 35)),
                    new(DayOfWeek.Friday, new(8, 45), new(12, 50)),
                    new(DayOfWeek.Saturday, null, null)
                }
            });

        await SaveChangesAsync();
    }
}
