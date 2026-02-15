# About

Shows how to toggle a EF Core [query filter](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.metadata.builders.entitytypebuilder-1.hasqueryfilter?view=efcore-9.0) by country code, along with specifying the country code from appsettings.json.


appsettings.json
```json
{
  "ConnectionStrings": {
    "MainConnection": "Data Source=.\\SQLEXPRESS;Initial Catalog=NorthWind2024;Integrated Security=True;Encrypt=False"
  },
  "EntityConfiguration": {
    "CreateNew": true
  },
  "ContextOptions": {
    "UseAuditInterceptor": true,
    "CustomersOptions": {
      "UseQueryFilter": true,
      "CountryCode": 20
    }
  }
}
```