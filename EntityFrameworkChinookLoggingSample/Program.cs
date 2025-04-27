using ChinookLoggingSample.Data;
using ChinookLoggingSample.Models;
using EntityFrameworkChinookLoggingSample.Classes;
using Microsoft.EntityFrameworkCore;
using static System.Environment;


namespace EntityFrameworkChinookLoggingSample;

internal partial class Program
{
    static void Main(string[] args)
    {
        using var context = new Context();

        int albumIdentifier = 129;

        var ledZeppelinIvAlbum = context
            .Album
            .AsNoTracking()
            .AsSplitQuery()
            .TagWithDebugInfo("LedZeppelin IV Album")
            .Include(a => a.Track.OrderBy(track => track.Name))
            .Include(album => album.Artist)
            .FirstOrDefault(a => a.AlbumId == albumIdentifier);


        var albums = context
            .Album
            .Include(album => album.Artist)
            .Include(a => a.Track)
            .FirstOrDefault(a => a.AlbumId == albumIdentifier);



        if (ledZeppelinIvAlbum is not null)
        {
            AnsiConsole.MarkupLine($"[cyan]Artist[/] [yellow]{ledZeppelinIvAlbum.Artist.Name}[/]");
            AnsiConsole.MarkupLine($" [cyan]Title[/] [yellow]{ledZeppelinIvAlbum.Title}[/]");

            foreach (var (track, index) in ledZeppelinIvAlbum.Track.Select((track, index) => (t: track, i: index)))
            {
                Console.WriteLine($"{index,-4:D2}{track.Name,-35}{track.Milliseconds.ShowTime(),-10}{track.Composer}");
            }

        }
        else
        {
            AnsiConsole.MarkupLine("[red]Failed to locate album![/]");
        }


        ExitPrompt();
    }

}