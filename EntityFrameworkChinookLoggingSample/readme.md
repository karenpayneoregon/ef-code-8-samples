# EF Core log to file benefits

Usually when a query fails to present expect results with EF Core a developer will setup a breakpoint, run code and examine results in Microsoft Visual Studio local window. Viewing results in the local window does not help to figure out the issue while using proper logging can point to the issue which can lead to modifications in code or farther research to fix the problem.

Learn how isolate EF Core logging to a file with sensitive information for development environment and stage and production environment without sensitive information to figure out queries that do not return expected results.

Environment, Microsoft Visual Studio 2022 or higher, Microsoft SQL Server, database Chinook using Microsoft Entity Framework Core 8.

