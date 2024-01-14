using GetWeekendDatesCorrectlyAppCore.Models;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618

namespace GetWeekendDatesCorrectlyAppCore.Data;

public class StoreContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=orders.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, OrderDate = new DateTime(2022,11,21), DeliveredDate = new DateTime(2022, 11, 23) }, 
            new Order { Id = 2, OrderDate = new DateTime(2022, 11, 23), DeliveredDate = new DateTime(2022, 11, 26) },
            new Order { Id = 3, OrderDate = new DateTime(2022, 11, 21), DeliveredDate = new DateTime(2022, 11, 27) },
            new Order { Id = 4, OrderDate = new DateTime(2022, 11, 21), DeliveredDate = new DateTime(2022, 11, 29) },
            new Order { Id = 5, OrderDate = new DateTime(2022, 11, 18), DeliveredDate = new DateTime(2022, 11, 19) },
            new Order { Id = 6, OrderDate = new DateTime(2022, 11, 16), DeliveredDate = new DateTime(2022, 11, 17) },
            new Order { Id = 7, OrderDate = new DateTime(2022, 11, 16), DeliveredDate = new DateTime(2022, 11, 17) },
            new Order { Id = 8, OrderDate = new DateTime(2022, 11, 1), DeliveredDate = new DateTime(2022, 11, 2) }
        );
    }
}