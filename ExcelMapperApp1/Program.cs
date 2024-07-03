using ExcelMapperApp1.Data;
using ExcelMapperApp1.Models;
using Ganss.Excel;
using ExcelMapperApp1.Classes;

namespace ExcelMapperApp1;

/// <summary>
/// Before running
/// 1. Create Examples database under .\SQLEXPRESS
/// 2. Run Populate.sql under the scripts folder
/// </summary>
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await ReadCustomersFromExcelToDatabase();
        await ReadPeopleWithNestedProperty();
        AnsiConsole.MarkupLine("[yellow]Done[/]");
        Console.ReadLine();
    }

    /// <summary>
    /// Read People with nested property Address from Excel
    /// See comments in <see cref="Person"/> class
    /// </summary>
    private static async Task ReadPeopleWithNestedProperty()
    {
        SpectreConsoleHelpers.PrintCyan();
        ExcelMapper excel = new();
        var people = await excel.FetchAsync<Person>("Nested.xlsx");
        AnsiConsole.MarkupLine(ObjectDumper.Dump(people).Colorize());
    }

    /// <summary>
    /// Read Customers from Excel and save to database
    /// 1. Read data from Excel
    /// 2. Remove rows where country is Germany
    /// 3. Save to SQL-Server database table
    /// </summary>
    private static async Task ReadCustomersFromExcelToDatabase()
    {
        SpectreConsoleHelpers.PrintCyan();

        try
        {
            DapperOperations operations = new();
            operations.Reset();

            const string excelFile = "Customers.xlsx";

            ExcelMapper excel = new();
            await using var context = new Context();
            
            var customers = (await excel.FetchAsync<Customers>(excelFile, nameof(Customers)))
                .ToList();
            
            var germanyItems = customers.Where(c => c.Country == "Germany").ToArray();

            foreach (var c in germanyItems)
                customers.Remove(c);

            context.Customers.AddRange(customers);
            var affected = await context.SaveChangesAsync();

            AnsiConsole.MarkupLine(affected > 0 ?
                $"[cyan]Saved[/] [b]{affected}[/] [cyan]records[/]" :
                "[red]Failed[/]");

        }
        catch (Exception ex)
        {
            ex.ColorWithCyanFuchsia();
        }
    }
}