using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityLibrary;
public static class EntityExtensions
{
    /// <summary>
    /// Setup provider to SQL-Server and logging to file for development as sensitive logging is enabled
    /// </summary>
    /// <param name="optionsBuilder"></param>
    /// <param name="connectionString">Valid connection string</param>
    public static void ConfigureWithFileLogging(this DbContextOptionsBuilder optionsBuilder, string connectionString)
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

    /// <summary>
    /// Setup provider to SQL-Server and logging to file for development as sensitive logging is disabled
    /// </summary>
    /// <param name="optionsBuilder"></param>
    /// <param name="connectionString">Valid connection string</param>
    public static void ConfigureWithFileLoggingOnly(this DbContextOptionsBuilder optionsBuilder, string connectionString)
    {
        optionsBuilder
            .UseSqlServer(connectionString)
            .LogTo(new DbContextToFileLogger().Log,
                new[]
                {
                    DbLoggerCategory.Database.Command.Name
                },
                LogLevel.Information);
    }
    /// <summary>
    /// Setup provider to SQL-Server no logging to file for development as sensitive logging is enabled
    /// </summary>
    /// <param name="optionsBuilder"></param>
    /// <param name="connectionString"></param>
    public static void ConfigureWithoutLogging(this DbContextOptionsBuilder optionsBuilder, string connectionString)
    {
        optionsBuilder
            .UseSqlServer(connectionString)
            .EnableSensitiveDataLogging();
    }
    public static void ConfigureUseHierarchyId(this DbContextOptionsBuilder optionsBuilder, string connectionString)
    {
        optionsBuilder
            .UseSqlServer(connectionString, sqlServerOptionsBuilder => sqlServerOptionsBuilder.UseHierarchyId())
            .EnableSensitiveDataLogging()
            .LogTo(new DbContextToFileLogger().Log,
                new[]
                {
                    DbLoggerCategory.Database.Command.Name
                },
                LogLevel.Information);
    }
}
