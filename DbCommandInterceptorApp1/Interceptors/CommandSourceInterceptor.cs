using System.Data.Common;
using DbPeekQueryLibrary.LanguageExtensions;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DbCommandInterceptorApp1.Interceptors;

public class CommandSourceInterceptor : DbCommandInterceptor
{
    public override InterceptionResult<DbDataReader> ReaderExecuting(
        DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
    {
        if (eventData.CommandSource == CommandSource.SaveChanges)
        {
            AnsiConsole.MarkupLine($"[lime]Saving changes for[/] [white]{eventData.Context!.GetType().Name}[/][lime]:[/]");
            Console.WriteLine();

            AnsiConsole.MarkupLine("[yellow]Command text for EF Core Command object from Karen's package[/]");
            Console.WriteLine(command.ActualCommandText());

            AnsiConsole.MarkupLine("[yellow]Command text for EF Core Command object raw[/]");
            Console.WriteLine(command.CommandText);
        }

        return result;
    }
}