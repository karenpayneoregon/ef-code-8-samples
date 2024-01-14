using DbCommandInterceptorApp1.Classes;
using DbCommandInterceptorApp1.Interceptors;
using DbCommandInterceptorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace DbCommandInterceptorApp1.Data;

public class CustomersContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .EnableSensitiveDataLogging()
            .AddInterceptors(new CommandSourceInterceptor())
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCoreSample1");
    }
}