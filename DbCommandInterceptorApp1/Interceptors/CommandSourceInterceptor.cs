using System.Data.Common;
using DbPeekQueryLibrary.LanguageExtensions;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DbCommandInterceptorApp1.Interceptors;

/// <summary>
/// Represents an interceptor for database commands that provides additional functionality 
/// when executing commands in Entity Framework Core.
/// </summary>
/// <remarks>
/// This class extends <see cref="Microsoft.EntityFrameworkCore.Diagnostics.DbCommandInterceptor"/> 
/// to inspect and log database commands, particularly during save operations. It allows for 
/// custom handling of command execution, such as logging command text and providing insights 
/// into the command source.
/// </remarks>
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