using EntityLibrary;
using ExecuteUpdateDeleteSampleApp.Classes;
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

}
