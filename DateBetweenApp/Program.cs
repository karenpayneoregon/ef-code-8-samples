using DateBetweenApp.Classes;
using DateBetweenApp.Data;
// ReSharper disable PossibleInvalidOperationException

namespace DateBetweenApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        using var context = new Context();
        
        DateOnly start = new DateOnly(1962,1,1);
        DateOnly end = new DateOnly(1968,1,1);


        List<DateOnly?> results = context.Events
            .IsStartDateBetween(start,end)
            .Select(x => x.StartDate)
            .ToList();

        Console.WriteLine(string.Join(",", results));
        Console.WriteLine();
        AnsiConsole.MarkupLine("[yellow]Press Enter to quit[/]");
        Console.ReadLine();
    }

}