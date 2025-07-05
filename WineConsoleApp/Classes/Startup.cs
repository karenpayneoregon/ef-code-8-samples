using Microsoft.EntityFrameworkCore;
using Spectre.Console;
using WineConsoleApp.Data;

namespace WineConsoleApp.Classes;
public static class Startup
{
    /// <summary>
    /// Recreate database with spinner
    /// </summary>
    public static void Clean()
    {
        if (!AppConfigLoader.LoadSettings().UseMockedData)
        {
            AnsiConsole.Status()

                .Start("[cyan]Skipping recreating database[/]", ctx =>
                {

                    Thread.Sleep(2000);

                    ctx.Spinner(Spinner.Known.Star);
                    ctx.SpinnerStyle(Style.Parse("cyan"));

                });

            return;
        }

        using var context = new WineContext();
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
