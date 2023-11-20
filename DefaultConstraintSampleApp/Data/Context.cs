
using EntityLibrary;
using UtilityLibarary;

// ReSharper disable once CheckNamespace
namespace ComplexTypesSampleApp.Data;

using DefaultConstraintSampleApp.Models;
using Microsoft.EntityFrameworkCore;

internal class Context : DbContext
{
    public Context() { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.ConfigureWithFileLogging(DataConnections.Instance.MainConnection);

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>()
            .Property(e => e.IsActive)
            .HasDefaultValueSql("1");

        modelBuilder.Entity<User>()
            .Property(e => e.Credits)
            .HasDefaultValue(100);

        modelBuilder.Entity<Course>()
            .Property(e => e.Level)
            .HasDefaultValue(Level.Intermediate);

        modelBuilder.Entity<AccountWithSentinel>()
            .Property(e => e.IsActive)
            .HasDefaultValueSql("1")
            .HasSentinel(true);

        modelBuilder.Entity<UserWithSentinel>()
            .Property(e => e.Credits)
            .HasDefaultValue(100)
            .HasSentinel(-1);

        modelBuilder.Entity<CourseWithSentinel>()
            .Property(e => e.Level)
            .HasDefaultValue(Level.Intermediate)
            .HasSentinel(Level.Unspecified);

        modelBuilder.Entity<AccountWithNullableBackingField>()
            .Property(e => e.IsActive)
            .HasDefaultValueSql("1");

        modelBuilder.Entity<UserWithNullableBackingField>()
            .Property(e => e.Credits)
            .HasDefaultValue(100);

        modelBuilder.Entity<CourseWithNullableBackingField>()
            .Property(e => e.Level)
            .HasDefaultValue(Level.Intermediate);
    }
}
