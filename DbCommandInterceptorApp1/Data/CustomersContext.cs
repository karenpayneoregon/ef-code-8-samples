
using System.Diagnostics;
using DbCommandInterceptorApp1.Classes.Configuration;
using DbCommandInterceptorApp1.Interceptors;
using DbCommandInterceptorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace DbCommandInterceptorApp1.Data;

public class CustomersContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (Debugger.IsAttached)
        {
            optionsBuilder
                .EnableSensitiveDataLogging()
                .AddInterceptors(new AuditInterceptor())
                .AddInterceptors(new CommandSourceInterceptor())
                .UseSqlServer(ConnectionReader.GetMainConnectionString());
        }
        else
        {
            optionsBuilder
                .AddInterceptors(new AuditInterceptor())
                .AddInterceptors(new CommandSourceInterceptor())
                .UseSqlServer(ConnectionReader.GetMainConnectionString());

        }
    }
}