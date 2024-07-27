# About

Minimal code to connect to a specific database table using conventional methods as per below. 



```csharp
        builder.Services.AddDbContextPool<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MainConnection"))
            .EnableSensitiveDataLogging()
            .LogTo(new DbContextToFileLogger().Log, new[]
                {
                    DbLoggerCategory.Database.Command.Name
                },
                LogLevel.Information));
```

What is important is there is a swtich to create new data for EF Core or not using [Bogus](https://www.nuget.org/packages/Bogus) and [ConsoleConfigurationLibrary](https://www.nuget.org/packages/ConsoleConfigurationLibrary/1.0.0.4?_src=template) packages.

ConsoleConfigurationLibrary package works desktop and web projects.

EF Core Logging: [EntityCoreFileLogger](https://www.nuget.org/packages/EntityCoreFileLogger/1.0.0?_src=template) package.
