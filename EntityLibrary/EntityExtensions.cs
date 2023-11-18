using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityLibrary;
public static class EntityExtensions
{
    public static void Configure(this DbContextOptionsBuilder optionsBuilder, string connectionString)
    {
        optionsBuilder
            .UseSqlServer(connectionString)
            .EnableSensitiveDataLogging()
            .LogTo(new DbContextToFileLogger().Log,
                new[]
                {
                    DbLoggerCategory.Database.Command.Name
                },
                LogLevel.Information);
    }
}
