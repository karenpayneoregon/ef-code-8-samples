# HierarchyId in .NET and EF Core

This sample app demonstrates how to use the [HierarchyId in .NET and EF Core](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/whatsnew#hierarchyid-in-net-and-ef-core) API.

Azure SQL and SQL Server have a special data type called [hierarchyid](https://learn.microsoft.com/en-us/sql/t-sql/data-types/hierarchyid-data-type-method-reference?view=sql-server-ver16) that is used to store [hierarchical data](https://learn.microsoft.com/en-us/sql/relational-databases/hierarchical-data-sql-server?view=sql-server-ver16). In this case, "hierarchical data" essentially means data that forms a tree structure, where each item can have a parent and/or children. Examples of such data are:

- An organizational structure
- A file system
- A set of tasks in a project
- A taxonomy of language terms
- A graph of links between Web pages
- The database is then able to run queries against this data using its hierarchical structure. For example, a query can find ancestors and dependents of given items, or find all items at a certain depth in the hierarchy.

The code was taken from this repository [project](https://github.com/dotnet/EntityFramework.Docs/tree/main/samples/core/Miscellaneous/NewInEFCore8) and modified for the reader to learn from even though the original code is easy to follow but was generic to suite several different ways of writing the code.

- Configuration for complex types is done in the `OnModelCreating` method of the `Context` class. Configuration may also be done with data attributes, see the docs.
- Connection string is read from appsettings.json
    - Currently set to create Karen6 database under localdb, might want to change the name
- EF Core logs to a file under the application folder