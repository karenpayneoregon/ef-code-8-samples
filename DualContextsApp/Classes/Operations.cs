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

    /// <summary>
    /// Dapper version of <see cref="NorthAddCustomer"/> which gets the primary key
    /// </summary>
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
        
        var parameters = new DynamicParameters();
        
        parameters.Add("@CompanyName", cust.CompanyName);
        parameters.Add("@ContactId", cust.ContactId);
        parameters.Add("@Street", cust.Street);
        parameters.Add("@City", cust.City);
        parameters.Add("@Region", cust.Region);
        parameters.Add("@PostalCode", cust.PostalCode);
        parameters.Add("@CountryIdentifier", cust.CountryIdentifier);
        parameters.Add("@Phone", cust.Phone);
        parameters.Add("@ContactTypeIdentifier", cust.ContactTypeIdentifier);

        parameters.Add("Identifier", dbType: DbType.Int32, direction: ParameterDirection.Output);
        
        await using var cn = new SqlConnection(Instance.SecondaryConnection);
        await cn.ExecuteAsync("dbo.usp_AddCustomer", parameters, commandType: CommandType.StoredProcedure);
        var id = parameters.Get<int?>("Identifier");
        cust.CustomerIdentifier = id.Value ;
        
    }
}