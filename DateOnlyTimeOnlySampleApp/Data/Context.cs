using DateOnlyTimeOnlySampleApp.Models;
using EntityLibrary;
using UtilityLibarary;

namespace DateOnlyTimeOnlySampleApp.Data;

internal partial class Context : DbContext
{

    public DbSet<School> Schools => Set<School>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder.ConfigureWithFileLogging(DataConnections.Instance.MainConnection);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<School>().OwnsMany(e => e.OpeningHours).ToJson();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
    }
}
