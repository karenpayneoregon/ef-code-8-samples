using DatabaseCheckedApp.Classes;
using DatabaseCheckedApp.Classes.Configuration;
using DatabaseCheckedApp.Classes.Helpers;
using DatabaseCheckedApp.Data;
using Serilog;

namespace DatabaseCheckedApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {

        await Setup();

        await using var context = new Context();

        var tableNames = ApplicationConfiguration.GetTableNames();

        if (DbContextHelpers.FullCheck(context, tableNames))
        {
            var ops = new DataOperations(context);
            var customers = ops.GetCustomers();

            AnsiConsole.MarkupLine("[yellow]Customers[/]");

            AnsiConsole.MarkupLine(
                ObjectDumper.Dump(customers)
                    .Replace("{Customer}", "{[cyan]Customer[/]}")
                    .Replace("{ContactType}", "{[yellow]ContactType[/]}")
                    .Replace("{Gender}", "{[yellow]Gender[/]}")
                    .Replace("null --> Circular reference detected", "") // no need to show this
                    );

            Console.WriteLine();

            AnsiConsole.MarkupLine("[yellow]Tables and row count[/]");
            var tableInfos = await EntityQueryHelpers.GetTableRowCountsAsync();

            Console.WriteLine(ObjectDumper.Dump(tableInfos));
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Create the database and run the script under[/][cyan] Data scripts[/]");
        }

        // Allows a developer to see the log file before the console closes e.g. in VS Code
        await Log.CloseAndFlushAsync();

        ExitPrompt();

    }
}