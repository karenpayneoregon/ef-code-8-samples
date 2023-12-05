# About


EF Core code samples using a modified version of NorthWind database, script to create and populate is located in the script folder.

- `EmployeeOperations.EmployeeReportsTo` is an example of a self-referencing table for managers and workers.

![Screenshot](assets/screenshot.png)

## Database

- The database is expected to be under SQLEXPRESS (see appsettings.json), if different than change to the desired server.
- Create NorthWind2023
- Run Scripts\script.sql to create and populate tables.

## Notes

- Originally written in .NET Core 5, now .NET Core 8
- This project came from another Visual Studio solution which was setup with EF Core and refacored to use NorthWind2023Library.
- Makes us of [Collection expressions](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-12.0/collection-expressions)