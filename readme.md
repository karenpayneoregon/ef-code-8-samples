# Entity Framework Core 8 code samples

The intent for this repository is to demonstrate new features for Entity Framework Core 8. Base [code samples](https://github.com/dotnet/EntityFramework.Docs/tree/main/samples/core/Miscellaneous/NewInEFCore8) were obtained **from Microsoft** which are fantastic but not setup for newcomers to learn from so those code samples were simply refactored for ease of learning.

Entity Framework Core 8: [Improved JSON, queryable collections , and more…](https://www.youtube.com/watch?v=_8iH5QnkIJo&list=PLdo4fOcmZ0oULyHSPBx-tQzePOYlhvrAU&t=2s) | .NET Conf 2023

> **Note**
> Extracting code samples is not as easy as many developers would think, hopefully they are of use.




## Projects

- Projects are listed as they appear in Solution Explorer
- Many of the console projects use my simple [connection library](https://www.nuget.org/packages/ConfigurationLibrary/) to read connection strings from appsettings.json. The library supports multiple environments without changing between different appsettings file or depend on environment variables and is mainly for writing code samples yet good enough for real applications.
- EF Core loggings, some projects use logging from the project EntityLibrary while others have looging within. This comes from not writing all code samples at once.
- `NorthWind` SQL-Server databases, there are two, NorthWind2023 and NorthWind2024. There are minor differences between the two but for the most part are interchangeable.
- Many projects with a DbContext were reverse engineered using EF Power Tools except those which came from Microsoft.

| Project        |   Description    |   Comments |
|:------------- |:-------------|:-------------|
| HasQueryFilterRazorApp | This project done with Razor Pages shows off visually how EF Core global query filters work by showing a list which provides an action to soft delete records while another page allows reversing the soft delete of records.  | ShadowProperties project for actual data operations. |
| EntityLibrary | A class project with a class to log EF Core actions to a file and extension methods for setting up EF Core connections to SQL-Server. | With connections, always consider not exposing sensitive information as its possible with the code provided. The code provided is solid other than no using secrets. |
| NorthWind2023Library | Dedicated to interacting with the SQL Server database NothWind2023. | Under the folder Templates is a T4 template for creating an enum for a table country. |
| ShadowProperties | This project contains code to demonstrate global query filtering.  | The DbContext is a partial class with some functionality broken out under a folder beneath the main DbContext class. |
| UtilityLibarary | Contains some connection helpers and Spectre.Console helper methods |  |
| AccessEntityFramework | Demonstrates working with Microsoft Access database with EF Core. This is to assist developers that are using Access databases to transition to EF Core and from there transition to SQL-Server or other major databases. | [From MS-Access to EF Core (C#)](https://dev.to/karenpayneoregon/from-ms-access-to-ef-core-c-14nn) article which has the same source code in EF Core 7 while here EF Core 8 is used. This has been a popular topic at DEV |
| BooksApp | This project shows two different ways to group books (the model) by price range. The methods used are benchmarked. |  |
| ComplexTypesSampleApp | This sample app demonstrates how to use the [Complex Types](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/whatsnew#value-objects-using-complex-types) API to create, read, update complex types. The code was taken from this repository [project](https://github.com/dotnet/EntityFramework.Docs/tree/main/samples/core/Miscellaneous/NewInEFCore8) and modified for the reader to learn from even though the original code is easy to follow but was generic to suite several different ways of writing the code. |  |
| ComputedColumnsApp | This project show how computed columns can be used with EF Core. Note EF Power Tools was used to reverse engineer the database and properly recognize computed columns. | See also [SQL-Server: Computed columns with Ef Core](https://dev.to/karenpayneoregon/sql-server-computed-columns-with-ef-core-3h8d) article.
 |
| CreateAndPopulateSqlServerApp | Port from EF Core 7 to EF Core 8 for an example of [interceptors](https://learn.microsoft.com/en-us/ef/core/logging-events-diagnostics/interceptors). | See [EF Core debugging part 1](https://dev.to/karenpayneoregon/ef-core-debugging-part-1-512f) article for details using an `iterceptor` for save changes. |
| DateBetweenApp | A demonstration for `DateOnly` with a special extension method for determining if a date is between two dates. |  |
| DateOnlyTimeOnlySampleApp | An example for working with `DateOnly` and `Json columns`. | The code was taken from this repository [project](https://github.com/dotnet/EntityFramework.Docs/tree/main/samples/core/Miscellaneous/NewInEFCore8) and modified for the reader to learn from even though the original code is easy to follow but was generic to suite several different ways of writing the code. |
| DbCommandInterceptorApp1 | A demonstration for an interceptor for a special way to get changes during SaveChanges and another example for incepting the data reader for EF Core. |  |
| DefaultConstraintSampleApp | This sample app demonstrates how to use the [Sentinel values and database defaults](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/whatsnew#sentinel-values-and-database-defaults) API |  |
| ExecuteUpdateDeleteSampleApp | A demonstration for using [ExecuteUpdateAsync](https://learn.microsoft.com/en-us/ef/core/saving/execute-insert-update-delete) in a more realistic examples than most found on the web. |  |
| ExecuteUpdateSampleApp | Show two different method to update a property of an entity using custom methods with ExecuteUpdateAsync. |  |
| HasConversion_Bool_ColorApp | Demonstrates value converters for bool to string, System.Drawing.Color to and from string and DateTime local to UTC. |  |
| HierarchyIdSampleApp | This sample app demonstrates how to use the [HierarchyId in .NET and EF Core](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/whatsnew#hierarchyid-in-net-and-ef-core) API. | See project readme for more details |
| ImmutableComplexTypesSampleApp | This sample app demonstrates how to use the [Primitive collection properties](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/whatsnew#primitive-collection-properties) API  | See project readme for more details  |
| NorthWind2023App | Shows taking date time column in a North wind database table to date column as the time segment was never used than changed the EF Core model to use DateOnly rather than DateTime. | Depends on class project NorthWind2023Library |
| NorthWind2023ReportsToApp | `EmployeeOperations.EmployeeReportsTo` is an example of a self-referencing table for managers and workers. |  |
| TimeBetweenApp | An example for TimeOnly [IsBetween](https://learn.microsoft.com/en-us/ef/core/providers/sql-server/functions) which was introduced with EF Core 8. | This is for TimeOnly struct |
| UserDefineFunctionMapping1 | EF Core allows for using user-defined SQL functions in queries. To do that, the functions need to be mapped to a CLR method during model configuration. When translating the LINQ query to SQL, the user-defined function is called instead of the CLR function it has been mapped to. | Code taken from Microsoft and implemented by Karen |
| WineConsoleApp | A basic code sample on working with [enumerations](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum) as a model for EF Core 8. For the demonstration to be easy to run the first time executing the application a check is done to see if the database exists, if not, the database is created and tables are populated in the DbContext. | Has Value conversions and T4 templates |
| CachingInterception | Interceptors Code sample from Microsoft, refactored for ease of learning by Karen. | In this sample, logging is different from all other projects in this repository where other projects which write to a log file per day, this sample uses a single log file as per [Microsoft docs](https://learn.microsoft.com/en-us/ef/core/logging-events-diagnostics/simple-logging#logging-to-a-file). |
| GetWeekendDatesCorrectlyAppCore | Reading EF Core error messages | See project readme file for details |
|  |  |  |
|  |  |  |
|  |  |  |
|  |  |  |