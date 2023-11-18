using ComplexTypesSampleApp.Classes;
using ComplexTypesSampleApp.Models;
using EntityLibrary;
using UtilityLibarary;

namespace ComplexTypesSampleApp.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

internal class Context : DbContext
{
    public Context() { }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.Configure(DataConnections.Instance.MainConnection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .ComplexProperty(e => e.Address);

        modelBuilder.Entity<Order>(b =>
        {
            b.ComplexProperty(e => e.BillingAddress);
            b.ComplexProperty(e => e.ShippingAddress);
        });
    }
}
