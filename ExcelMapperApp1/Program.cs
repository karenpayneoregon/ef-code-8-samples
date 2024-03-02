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
        try
        {
            DapperOperations operations = new();
            operations.Reset();

            const string excelFile = "Customers.xlsx";

            ExcelMapper excel = new();
            await using var context = new Context();

            var customers = (await excel.FetchAsync<Customers>(excelFile,
                nameof(Customers)))
                .ToList();

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

        AnsiConsole.MarkupLine("[yellow]Done[/]");
        Console.ReadLine();
    }
}