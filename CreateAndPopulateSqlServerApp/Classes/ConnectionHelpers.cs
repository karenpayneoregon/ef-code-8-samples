
using ConfigurationLibrary.Classes;
using CreateAndPopulateSqlServerApp.Interceptors;
using EntityLibrary;
using Microsoft.EntityFrameworkCore;


namespace CreateAndPopulateSqlServerApp.Classes;

public class ConnectionHelpers
{
    public static void StandardLoggingSqlServer(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(ConfigurationHelper.ConnectionString())
            .EnableSensitiveDataLogging()
            .AddInterceptors(new AuditInterceptor())
            .LogTo(new DbContextToFileLogger().Log,
                new[]
                {
                    DbLoggerCategory.Database.Command.Name
                },
                Microsoft.Extensions.Logging.LogLevel.Information);

    }
}