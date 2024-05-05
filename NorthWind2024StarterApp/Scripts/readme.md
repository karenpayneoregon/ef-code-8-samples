
```csharp
public static List<CustomersCountries> GetCustomersCountriesFiltered(List<int> countries)
{
        
    using var context = new Context();
        
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
```

Generated SQL

```sql
SELECT 
   [n].[CompanyName], 
   [n].[CountryIdentifier], 
   [n].[CountryName], 
   [n].[CustomerIdentifier]
FROM (
    SELECT Cust.CustomerIdentifier,
            Cust.CompanyName,
            Cust.CountryIdentifier,
            CO.[Name] AS CountryName
    FROM dbo.Customers AS Cust
        INNER JOIN dbo.Countries AS CO
            ON Cust.CountryIdentifier = CO.CountryIdentifier
) AS [n]
WHERE [n].[CountryIdentifier] IN (
    SELECT [c].[value]
    FROM OPENJSON(@__countries_1) WITH ([value] int '$') AS [c]
)
```