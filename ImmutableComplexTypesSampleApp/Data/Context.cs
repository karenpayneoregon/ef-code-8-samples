using EntityLibrary;
using ImmutableComplexTypesSampleApp.Classes;
using ImmutableComplexTypesSampleApp.Models;
using Microsoft.Extensions.Logging;
using UtilityLibarary;

namespace ImmutableComplexTypesSampleApp.Data;

internal class Context : DbContext
{
    public Context() { }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWithFileLogging(DataConnections.Instance.MainConnection);
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
