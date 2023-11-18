using ImmutableComplexTypesSampleApp.Classes;
using ImmutableComplexTypesSampleApp.Models;
using Microsoft.Extensions.Logging;

namespace ImmutableComplexTypesSampleApp.Data;

internal class Context : DbContext
{
    public Context() { }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder
            .UseSqlServer(DataConnections.Instance.MainConnection)
            .EnableSensitiveDataLogging()
            .LogTo(new DbContextToFileLogger().Log,
                new[]
                {
                    DbLoggerCategory.Database.Command.Name
                },
                LogLevel.Information);
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().ComplexProperty(e => e.Address,
            b =>
            {
                b.Property(e => e.Line1);
                b.Property(e => e.Line2);
                b.Property(e => e.City);
                b.Property(e => e.Country);
                b.Property(e => e.PostCode);
            });

        modelBuilder.Entity<Order>(b =>
        {
            b.ComplexProperty(e => e.BillingAddress,
                b =>
                {
                    b.Property(e => e.Line1);
                    b.Property(e => e.Line2);
                    b.Property(e => e.City);
                    b.Property(e => e.Country);
                    b.Property(e => e.PostCode);
                });

            b.ComplexProperty(e => e.ShippingAddress,
                b =>
                {
                    b.Property(e => e.Line1);
                    b.Property(e => e.Line2);
                    b.Property(e => e.City);
                    b.Property(e => e.Country);
                    b.Property(e => e.PostCode);
                });
        });
    }
}
