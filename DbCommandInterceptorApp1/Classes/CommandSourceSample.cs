using DbCommandInterceptorApp1.Data;
using DbCommandInterceptorApp1.Models;


namespace DbCommandInterceptorApp1.Classes;

public static partial class CommandSourceSample
{
    public static void GetCommandSource()
    {
        using CustomersContext context = new();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.Add(
            new Customer
            {
                FirstName = "Karen",
                LastName = "Payne",
                JoinDate = new DateOnly(2023,1,2)
            });

        ;

        context.SaveChanges();

        var customer = context.Customers.FirstOrDefault();
        customer.JoinDate = new DateOnly(2024, 1, 12);

        context.SaveChanges();

        context.ChangeTracker.Clear();

        var customers = context.Customers.ToList();

        Console.WriteLine(ObjectDumper.Dump(customers));
    }
}