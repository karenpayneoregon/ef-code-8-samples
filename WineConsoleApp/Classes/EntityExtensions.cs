using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace WineConsoleApp.Classes;
public static class EntityExtensions
{
    /// <summary>
    /// Recreate database with spinner
    /// </summary>
    public static void CleanStart(this DbContext context)
    {
        AnsiConsole.Status()

            .Start("Recreating database...", ctx =>
            {
                
                Thread.Sleep(500);

                ctx.Spinner(Spinner.Known.Star);
                ctx.SpinnerStyle(Style.Parse("cyan"));

                ctx.Status("Removing");
                context.Database.EnsureDeleted();
                
                ctx.Status("Creating");
                context.Database.EnsureCreated();

            });

    }
}
