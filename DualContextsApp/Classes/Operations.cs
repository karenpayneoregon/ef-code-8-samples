#nullable disable
using System.Data;
using Dapper;
using DualContextsApp.ChinookModels;
using DualContextsApp.Data;
using DualContextsApp.NorthModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static ConsoleConfigurationLibrary.Classes.AppConnections;
// ReSharper disable PossibleInvalidOperationException

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

    public static async Task<(List<AlbumSpecial> album, string artist)> GetAlbum(int artistId = 22, int albumId = 129)
    {
        await using var context = new ChinookContext();

        var artistName = (await context.Artist.FirstOrDefaultAsync(x => x.ArtistId == artistId)).Name;

        FormattableString sql =
            $"""
             SELECT A.AlbumId,
                    A.Title,
                    A.ArtistId,
                    T.TrackId,
                    T.Name As SongName,
                    T.Milliseconds,
                    FLOOR(T.Milliseconds / (1000 * 60)) % 60 AS Minutes
              FROM  dbo.Album AS A
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
    /// <summary>
    /// Retrieves album details and the artist's name using a stored procedure with parameters.
    /// </summary>
    /// <param name="artistId">The identifier of the artist. Default is 22.</param>
    /// <param name="albumId">The identifier of the album. Default is 129.</param>
    /// <returns>A tuple containing a list of <see cref="AlbumSpecial"/> and the artist's name.</returns>
    public static async Task<(List<AlbumSpecial> album, string artist)> GetAlbumStoredProcedureParameters(int artistId = 22, int albumId = 129)
    {
        await using var context = new ChinookContext();

        var artistName = (await context.Artist.FirstOrDefaultAsync(x => x.ArtistId == artistId)).Name;

        IEnumerable<AlbumSpecial> data = context.Database
            .SqlQuery<AlbumSpecial>($"exec ups_LedZeppelinIVAlbumParams @AlbumId = {albumId}")
            .TagWith($"Chinook {nameof(GetAlbumStoredProcedureParameters)}")
            .AsEnumerable();

        return (data.ToList(), artistName);
    }

    /// <summary>
    /// Add new record without getting the primary key while <see cref="NorthAddCustomerDapper"/> uses
    /// the same stored procedures and gets the primary key
    /// </summary>
    public static async Task NorthAddCustomer()
    {
        NorthModels.Customer cust = new()
        {
            CompanyName = "New Customer",
            ContactId = 1,
            Street = "123 Main St",
            City = "New York",
            Region = "NY",
            PostalCode = "10001",
            CountryIdentifier = 1,
            Phone = "123-456-7890",
            Fax = "987-654-3210",
            ContactTypeIdentifier = 1,
            ModifiedDate = DateTime.Now
        };

        await using var context = new NorthContext();
        var affected = await context.Database.ExecuteSqlAsync(
            $"""
             EXEC dbo.usp_AddCustomer
             @CompanyName = {cust.CompanyName},
             @ContactId = {cust.ContactId},
             @Street = {cust.Street},
             @City = {cust.City},
             @Region = {cust.Region},
             @PostalCode = {cust.PostalCode},
             @CountryIdentifier = {cust.CountryIdentifier},
             @Phone = {cust.Phone},
             @ContactTypeIdentifier = {cust.ContactTypeIdentifier}
             """);



    }



    public static async Task NorthAddCustomerDapper()
    {

        NorthModels.Customer cust = new()
        {
            CompanyName = "New Customer",
            ContactId = 1,
            Street = "123 Main St",
            City = "New York",
            Region = "NY",
            PostalCode = "10001",
            CountryIdentifier = 9,
            Phone = "123-456-7890",
            Fax = "987-654-3210",
            ContactTypeIdentifier = 3
        };


        await using var cn = new SqlConnection(Instance.SecondaryConnection);

        var id = await cn.ExecuteScalarAsync<int>("dbo.usp_AddCustomer1",
            new
            {
                cust.CompanyName,
                cust.ContactId,
                cust.Street,
                cust.City,
                cust.Region,
                cust.PostalCode,
                cust.CountryIdentifier,
                cust.Phone,
                cust.ContactTypeIdentifier
            }, commandType: CommandType.StoredProcedure);


        cust.CustomerIdentifier = id;
        
    }
}