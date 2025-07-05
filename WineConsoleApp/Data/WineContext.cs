using EntityCoreFileLogger;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WineConsoleApp.Classes;
using WineConsoleApp.Models;
using static ConfigurationLibrary.Classes.ConfigurationHelper;
#pragma warning disable CS8618

namespace WineConsoleApp.Data;

public class WineContext : DbContext
{
    public DbSet<Wine> Wines { get; set; }
    public DbSet<WineTypes> WineTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseSqlServer(ConnectionString(),
                sqlServerOptionsAction: sqlOptions => { sqlOptions.CommandTimeout(5); sqlOptions.EnableRetryOnFailure(); }) 
            .EnableSensitiveDataLogging()     // for development only
            .LogTo(new DbContextToFileLogger().Log,
                [
                    DbLoggerCategory.Database.Command.Name
                ],
                LogLevel.Information);

    /// <summary>
    /// * Provide predefined data
    /// * Setup conversion for WineType (enum)
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Wine>()
            .Property(e => e.WineType)
            .HasConversion<int>();


        if (!AppConfigLoader.LoadSettings().UseMockedData) return;
        modelBuilder.Entity<WineTypes>().HasData(MockedData.GetWineTypes());
        modelBuilder.Entity<Wine>().HasData(MockedData.GetWines());


    }
}