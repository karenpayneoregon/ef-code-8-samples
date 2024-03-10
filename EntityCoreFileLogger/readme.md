# File log for EF Core

Provides a class to log EF Core operations


## Instructions

Add the following to the project that uses EF Core or the base project where the base project uses a class project with EF Core operations.

```xml
<Target Name="MakeLogDir" AfterTargets="Build">
   <!-- Create folder LogFiles than each day create a folder with the current date -->
   <MakeDir Directories="$(OutDir)LogFiles\$([System.DateTime]::Now.ToString(yyyy-MM-dd))" />
</Target>
```

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

