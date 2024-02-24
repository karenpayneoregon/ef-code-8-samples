using ChinookLoggingSample.Data;
using ChinookLoggingSample.Models;
using EntityFrameworkChinookLoggingSample.Classes;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkChinookLoggingSample;

internal partial class Program
{
    static void Main(string[] args)
    {
        using var context = new Context();

        int albumIdentifier = 129;

        //var LedZeppelin_IV_Album = context
        //    .Album
        //    .AsNoTracking()
        //    .AsSplitQuery()
        //    .Include(a => a.Track.OrderBy(track => track.Name))
        //    .Include(album => album.Artist)
        //    .TagWith("LedZeppelin_IV_Album")
        //    .FirstOrDefault(a => a.AlbumId == albumIdentifier);

        var ledZeppelinIvAlbum = context
            .Album
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("LedZeppelin_IV_Album")
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
            Console.WriteLine();
            AnsiConsole.MarkupLine("[dodgerblue1]Song                               Time      Composer[/]");
            foreach (var track in ledZeppelinIvAlbum.Track)
            {
                Console.WriteLine($"{track.Name,-35}{track.Milliseconds.ShowTime(),-10}{track.Composer}");
            }
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Failed to locate album![/]");
        }


        ExitPrompt();
    }

}