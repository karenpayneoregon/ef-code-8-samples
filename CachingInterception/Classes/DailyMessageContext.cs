using System.IO;
using System.Threading.Tasks;
using Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Classes;

public class DailyMessageContext : DbContext
{
    private static readonly CachingCommandInterceptor _cachingInterceptor
        = new CachingCommandInterceptor();
    private readonly StreamWriter _logStream = 
        new("LogFiles\\ef-logs.txt", append: true);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .EnableSensitiveDataLogging()
            .AddInterceptors(_cachingInterceptor)
            .LogTo(_logStream.WriteLine, LogLevel.Information)
            .UseSqlite("DataSource=dailymessage.db");

    public DbSet<DailyMessage> DailyMessages { get; set; }

    public override void Dispose()
    {
        base.Dispose();
        _logStream.Dispose();
    }

    public override async ValueTask DisposeAsync()
    {
        await base.DisposeAsync();
        await _logStream.DisposeAsync();
    }
}