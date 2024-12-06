using NorthWind2023App.Classes;


namespace NorthWind2023App;

internal partial class Program
{
    static void Main(string[] args)
    {

        //_ = BenchmarkRunner.Run<NorthOperations>();
        NorthOperations.Extended();
        AnsiConsole.MarkupLine("[yellow]Done[/]");
        Console.ReadLine();
    }

}