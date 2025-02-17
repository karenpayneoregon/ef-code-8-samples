
using ConfigurationLibrary.Classes;
using CreateAndPopulateSqlServerApp.Interceptors;
using EntityLibrary;
using Microsoft.EntityFrameworkCore;


namespace CreateAndPopulateSqlServerApp.Classes;

public class ConnectionHelpers
{
    /// <summary>
    /// Configures the provided <see cref="DbContextOptionsBuilder"/> to use SQL Server with standard logging settings.
    /// </summary>
    /// <param name="optionsBuilder">
    /// The <see cref="DbContextOptionsBuilder"/> to configure.
    /// </param>
    /// <remarks>
    /// This method sets up the SQL Server connection using a connection string retrieved from the configuration,
    /// enables sensitive data logging, adds an <see cref="AuditInterceptor"/> for auditing purposes, 
    /// and configures logging to write database command information to a file using <see cref="DbContextToFileLogger"/>.
    /// </remarks>
    public static void StandardLoggingSqlServer(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(ConfigurationHelper.ConnectionString())
            .EnableSensitiveDataLogging()
            .AddInterceptors(new AuditInterceptor())
            .LogTo(new DbContextToFileLogger().Log, [DbLoggerCategory.Database.Command.Name],
                Microsoft.Extensions.Logging.LogLevel.Information);

    }
}