# About
This sample app demonstrates how to use the [Primitive collection properties](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/whatsnew#primitive-collection-properties) API 

The code was taken from this repository [project](https://github.com/dotnet/EntityFramework.Docs/tree/main/samples/core/Miscellaneous/NewInEFCore8) and modified for the reader to learn from even though the original code is easy to follow but was generic to suite several different ways of writing the code.

- Configuration for complex types is done in the `OnModelCreating` method of the `Context` class. Configuration may also be done with data attributes, see the docs.
- Connection string is read from appsettings.json
    - Currently set to create Karen1 database under localdb, might want to change the name
- EF Core logs to a file under the application folder
