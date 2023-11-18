using ComplexTypesSampleApp.Data;
using ComplexTypesSampleApp.Models;

namespace ComplexTypesSampleApp.Classes;
internal class Operations
{
    public static async Task ComplexTypesDemo()
    {
        PrintCyan();

        await using var context = new Context();
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        await context.SaveChangesAsync();

        RunningMessage("Database created");

        var customer = new Customer
        {
            Name = "Centro comercial Moctezuma",
            Address = new()
            {
                Line1 = "Sierras de Granada 9993",
                Line2 = "Suite 100",
                City = "Buenos Aires",
                Country = "Argentina",
                PostCode = "05022"
            }
        };

        context.Add(customer);
        await context.SaveChangesAsync();

        RunningMessage("Customer added");

        customer.Orders.Add(
            new Order
            {
                Contents = "Tesco Tasty Treats",
                BillingAddress = customer.Address,
                ShippingAddress = customer.Address,
            });

        await context.SaveChangesAsync();

        RunningMessage("Order added");

        customer.Address.Line1 = "Forsterstr. 57";
        await context.SaveChangesAsync();

        RunningMessage("Customer edited");
        Console.WriteLine();
    }
}

