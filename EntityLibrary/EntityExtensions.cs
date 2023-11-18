using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityLibrary;
public static class EntityExtensions
{
    /// <summary>
    /// Setup provider to SQL-Server and logging to file
    /// </summary>
    /// <param name="optionsBuilder"></param>
    /// <param name="connectionString">Valid connection string</param>
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
