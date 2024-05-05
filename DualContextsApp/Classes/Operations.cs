using DualContextsApp.ChinookModels;
using DualContextsApp.Data;
using DualContextsApp.NorthModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace DualContextsApp.Classes;
internal class Operations
{
    public static async Task<Album> LedZeppelinIV(int albumIdentifier = 129)
    {
        await using var context = new ChinookContext();
        
        return await context
            .Album
            .AsNoTracking()
            .AsSplitQuery()
            .TagWith("Chinook Split")
            .Include(a => a.Track.OrderBy(track => track.Name))
            .Include(album => album.Artist)
            .FirstOrDefaultAsync(a => a.AlbumId == albumIdentifier);
    }

    public static async Task<List<CustomersCountries>> GetCustomersCountriesFiltered(List<int> countries)
    {

        await using var context = new NorthContext();

        FormattableString sql =
            $"""
             SELECT Cust.CustomerIdentifier,
                    Cust.CompanyName,
                    Cust.CountryIdentifier,
                    CO.[Name] AS CountryName
             FROM dbo.Customers AS Cust
                 INNER JOIN dbo.Countries AS CO
                     ON Cust.CountryIdentifier = CO.CountryIdentifier
             """;


        IQueryable<CustomersCountries> data = context.Database
            .SqlQuery<CustomersCountries>(sql)
            .TagWith($"NorthWind2024 {nameof(GetCustomersCountriesFiltered)}")
            .Where(x => countries.Contains(x.CountryIdentifier));

        return data.ToList();
    }

    public static async Task<(List<AlbumSpecial> album, string artist)> GetAlbum(int artistId = 22,int albumId = 129)
    {
        await using var context = new ChinookContext();

        var artistName = (await context.Artist.FirstOrDefaultAsync(x => x.ArtistId == artistId)).Name;
        
        FormattableString sql =
            $"""
             SELECT     A.AlbumId,
                        A.Title,
                        A.ArtistId,
                        T.TrackId,
                        T.Name As SongName,
                        T.Milliseconds,
                        FLOOR(T.Milliseconds / (1000 * 60)) % 60 AS Minutes
              FROM      dbo.Album AS A
             INNER JOIN dbo.Track AS T
                ON A.AlbumId = T.AlbumId
             """;

        IQueryable<AlbumSpecial> data = context.Database
            .SqlQuery<AlbumSpecial>(sql)
            .TagWith($"Chinook {nameof(GetAlbum)}")
            .Where(x => x.AlbumId == albumId);
        
        return (data.ToList(), artistName);
    }

    public static async Task<(List<AlbumSpecial> album, string artist)> GetAlbumStoredProcedure(int artistId = 22, int albumId = 129)
    {
        await using var context = new ChinookContext();

        var artistName = (await context.Artist.FirstOrDefaultAsync(x => x.ArtistId == artistId)).Name;
        
        IEnumerable<AlbumSpecial> data = context.Database
            .SqlQuery<AlbumSpecial>(@$"exec ups_LedZeppelinIVAlbum")
            .TagWith($"Chinook {nameof(GetAlbumStoredProcedure)}")
            .AsEnumerable()
            .Where(x => x.AlbumId == albumId);

        return (data.ToList(), artistName);
    }

    public static async Task<(List<AlbumSpecial> album, string artist)> GetAlbumStoredProcedureParameters(int artistId = 22, int albumId = 129)
    {
        await using var context = new ChinookContext();

        var artistName = (await context.Artist.FirstOrDefaultAsync(x => x.ArtistId == artistId)).Name;

        IEnumerable<AlbumSpecial> data = context.Database
            .SqlQuery<AlbumSpecial>($"exec ups_LedZeppelinIVAlbumParams @AlbumId = {albumId}")
            .TagWith($"Chinook {nameof(GetAlbumStoredProcedureParameters)}")
            .AsEnumerable()
            .Where(x => x.AlbumId == albumId);

        return (data.ToList(), artistName);
    }
}