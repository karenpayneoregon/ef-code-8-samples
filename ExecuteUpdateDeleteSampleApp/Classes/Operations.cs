using ExecuteUpdateDeleteSampleApp.Data;
using ExecuteUpdateDeleteSampleApp.Models;
using static UtilityLibarary.SpectreConsoleHelpers;

namespace ExecuteUpdateDeleteSampleApp.Classes;
internal class Operations
{
    public static async Task ExecuteUpdateDeleteSample()
    {
        PrintCyan();

        await using var context = new Context();
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        RunningMessage("Database created");

        context.AddRange(
            new Store { Customers =
            {
                new CustomerWithStores
                {
                    Name = "Smokey", 
                    Region = "France"
                }
            }, Region = "France" },
            new Customer { Name = "Smokey", CustomerInfo = new() { Tag = "EF" } },
            new CustomerTpt { Name = "Willow" },
            new SpecialCustomerTpt { Name = "Olive" });

        await context.SaveChangesAsync();
        RunningMessage("Record added");

        var name = "Smokey";
        await context.Customers
            .Where(e => e.Name == name)
            .ExecuteUpdateAsync(
                s => 
                    s.SetProperty(b => b.CustomerInfo.Tag, "Tagged")
                    .SetProperty(b => b.Name, b => 
                        b.Name + "_Tagged"));

        RunningMessage("Updated");

        await context.CustomersWithStores
            .Where(e => e.Region == "France")
            .Union(context.Stores.Where(e => e.Region == "France")
                .SelectMany(e => e.Customers))
            .ExecuteUpdateAsync(s => 
                s.SetProperty(b => b.Tag, "The French Connection"));

        RunningMessage("Updated - Union");

        await context.TptSpecialCustomers
            .Where(e => e.Name == name)
            .ExecuteUpdateAsync(s => 
                s.SetProperty(b => b.Name, b => 
                    b.Name + " (Noted)"));

        RunningMessage("Update properties of a single table in a TPT hierarchy");

        await context.Customers.Where(e => e.Name == name).ExecuteDeleteAsync();
        RunningMessage("Delete entities returned by union but targeting a single table:");

        Console.WriteLine();
        RunningMessage("Done");

    }
}
