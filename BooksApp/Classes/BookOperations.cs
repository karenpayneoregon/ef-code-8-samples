using BooksApp.Data;
using Microsoft.EntityFrameworkCore;
using BenchmarkDotNet.Attributes;
using BooksApp.Models;

namespace BooksApp.Classes;

[MemoryDiagnoser]
[RankColumn, 
 MinColumn, 
 MaxColumn, 
 Q1Column, 
 Q3Column, 
 AllStatisticsColumn]
[JsonExporterAttribute.Full]
[GcServer(true)]
public partial class BookOperations
{
    [Benchmark]
    public async Task GroupBy()
    {
        await using var context = new BookContext();
        var books = await context.Book.ToListAsync();

        List<IGrouping<int, Book>> results = books
            .GroupBy(book => book.Price < 10 ? 10 : (book.Price < 20 ? 20 : 30))
            .OrderBy(grouping => grouping.Key)
            .ToList();

        //GroupNoSwitchOutput(results);
    }
    

    [Benchmark(Baseline = true)]
    public async Task Switch()
    {
        await using var context = new BookContext();
        var books = await context.Book.ToListAsync();

        List<GroupSwitch> results = books
            .GroupBy(book => book.Price switch
            {
                <= 10 => "Cheap",
                > 10 and <= 20 => "Medium",
                _ => "Expensive"
            })
            .Select(g => new GroupSwitch(g.Key, g.ToList()))
            .OrderBy(ca => ca.Category)
            .ToList();

        //GroupWithSwitchOutput(results);
    }
}