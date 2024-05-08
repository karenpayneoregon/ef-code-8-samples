# About

https://github.com/karenpayneoregon/ef-core-6-tips/tree/master/Experiment1

https://jaliyaudagedara.blogspot.com/2023/08/ef-core-80-preview-raw-sql-queries-for.html

https://learn.microsoft.com/en-us/ef/core/querying/sql-queries


Two examples for [SqlQuery](https://learn.microsoft.com/en-us/ef/core/querying/sql-queries#querying-scalar-non-entity-types)

## Two databases

NorthWind and Chinook

- Create and populate both via scripts under the Scripts folder
- Edit connection string in `appsettings.json` if not using .`\SQLEXPRESS`


## Run the application

Once the above has been completed to setup the databases.

- Build
- Run
- Inspect results.



## Main code

```csharp
using DualContextsApp.ChinookModels;
using DualContextsApp.Data;
using DualContextsApp.NorthModels;
using Microsoft.EntityFrameworkCore;

namespace DualContextsApp.Classes;
internal class Operations
{
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
            .Where(x => x.AlbumId == albumId);
        
        return (data.ToList(), artistName);
    }
}
```