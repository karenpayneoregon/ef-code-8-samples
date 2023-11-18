using ImmutableComplexTypesSampleApp.Data;
using ImmutableComplexTypesSampleApp.Models;

namespace ImmutableComplexTypesSampleApp.Classes;
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

        var customer = new Customer()
        {
            Name = "Willow", 
            Address = new(
                "Barking Gate", 
                null, 
                "Walpole St Peter", 
                "UK", 
                "PE14 7AV")
        };

        context.Add(customer);
        await context.SaveChangesAsync();

        customer.Orders.Add(
            new Order
            {
                Contents = "Tesco Tasty Treats", 
                BillingAddress = customer.Address, 
                ShippingAddress = customer.Address,
            });

        await context.SaveChangesAsync();

        var currentAddress = customer.Address;
        customer.Address = new Address(
            "Peacock Lodge", 
            currentAddress.Line2, 
            currentAddress.City, 
            currentAddress.Country, 
            currentAddress.PostCode);

        await context.SaveChangesAsync();

        RunningMessage("Finished");
    }
}

