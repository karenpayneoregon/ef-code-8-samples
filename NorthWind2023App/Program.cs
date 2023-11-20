using BenchmarkDotNet.Running;
using NorthWind2023App.Classes;
using NorthWind2023Library.Data;

namespace NorthWind2023App;

internal partial class Program
{
    static async Task Main(string[] args)
    {

        _ = BenchmarkRunner.Run<NorthOperations>();

        AnsiConsole.MarkupLine("[yellow]Done[/]");
        Console.ReadLine();
    }
}