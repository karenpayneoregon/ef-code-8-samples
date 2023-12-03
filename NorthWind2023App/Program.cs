using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;
using NorthWind2023App.Classes;
using NorthWind2023Library.Data;
using NorthWind2023Library.Models;
using NorthWind2023Library.Templates;


namespace NorthWind2023App;

internal partial class Program
{
    static void Main(string[] args)
    {

        _ = BenchmarkRunner.Run<NorthOperations>();

        AnsiConsole.MarkupLine("[yellow]Done[/]");
        Console.ReadLine();
    }

}