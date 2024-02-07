using TimeBetweenApp.Data;
using TimeBetweenApp.Models;
// ReSharper disable EntityFramework.UnsupportedServerSideFunctionCall

namespace TimeBetweenApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        using var context = new Context();
        TimeOnly start = new(6,0,0);
        TimeOnly end = new(9,0,0);
        IQueryable<TimeTable> results = context.TimeTables
            .Where(x => x.StartTime.Value.IsBetween(start,end));

        foreach (var item in results)
        {
            Console.WriteLine($"{item.Id,-4}" +
                              $"{item.StartTime,-14}" +
                              $"{item.FirstName,-15}" +
                              $"{item.LastName}");
        }
        AnsiConsole.MarkupLine("[yellow]Press Enter to exit[/]");
        Console.ReadLine();
    }
}

