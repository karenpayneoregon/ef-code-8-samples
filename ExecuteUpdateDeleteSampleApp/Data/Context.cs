using EntityLibrary;
using ExecuteUpdateDeleteSampleApp.Models;
using UtilityLibarary;

namespace ExecuteUpdateDeleteSampleApp.Data;

internal class Context : DbContext
{
    public Context() { }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<CustomerWithStores> CustomersWithStores => Set<CustomerWithStores>();
    public DbSet<Store> Stores => Set<Store>();
    public DbSet<CustomerTpt> TptCustomers => Set<CustomerTpt>();
    public DbSet<SpecialCustomerTpt> TptSpecialCustomers => Set<SpecialCustomerTpt>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWithFileLogging(DataConnections.Instance.MainConnection);
    }

}
