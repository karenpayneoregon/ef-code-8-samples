# File log for EF Core

Provides a class to log EF Core operations


## Instructions


Setup for ASP.NET Core

```csharp
builder.Services.AddDbContext<Context>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString(nameof(ConnectionStrings.NorthWindConnection)))
        .EnableSensitiveDataLogging()
        .LogTo(new DbContextToFileLogger().Log, new[]
            {
                DbLoggerCategory.Database.Command.Name
            },
            LogLevel.Information));
```

--- 

```csharp
builder.Services.AddDbContextPool<Context>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        .EnableSensitiveDataLogging()
        .LogTo(new DbContextToFileLogger().Log,
            new[] { DbLoggerCategory.Database.Command.Name },
            LogLevel.Information));
```

