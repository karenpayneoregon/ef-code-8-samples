using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using NorthWind2023Library.Data;
using NorthWind2023Library.Models;

namespace NorthWind2023App.Classes;

[MemoryDiagnoser]
[RankColumn,
 MinColumn,
 MaxColumn,
 Q1Column,
 Q3Column,
 AllStatisticsColumn]
[JsonExporterAttribute.Full]
[GcServer(true)]
public class NorthOperations
{
    public static async Task<Orders> GetOrder(int orderIdentifier = 10251)
    {
        await using var context = new Context();
        return await context.Orders
            .Include(o => o.Employee)
            .Include(o => o.ShipViaNavigation)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
            .ThenInclude(p => p.Category)
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(o => o.OrderID == orderIdentifier);
    }

    [Benchmark(Baseline = true)]
    public void GetOrdersNonCompiled()
    {
        int orderIdentifier = 10251;
        using var context = new Context();

        for (int index = 0; index < 100; index++)
        {
            Orders order = context.Orders
                .Include(o => o.Employee)
                .Include(o => o.ShipViaNavigation)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .ThenInclude(p => p.Category)
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefault(o => o.OrderID == orderIdentifier);
        }
    }

    [Benchmark]
    public void GetOrdersCompiled()
    {
        int orderIdentifier = 10251;
        using var context = new Context();
        for (int index = 0; index < 100; index++)
        {
            Orders order = context.GetOrder(orderIdentifier);
        }
    }

    public static void Extended(int customerId = 44)
    {
        using var context = new Context();
        var customer = context.Customers
            .Include(c => c.CountryIdentifierNavigation)
            .Include( c => c.Contact)
            .Include(c => c.Orders)
            .ThenInclude(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
            .ThenInclude(p => p.Category)
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefault(c => c.CustomerIdentifier == customerId);

        var greeting = Helpers.Greeting(customer);
    }



    public static OrderDetails SingleDetails()
    {
        using var context = new Context();
        var list = context.OrderDetails
            .Include(od => od.Order)
            .Include(od => od.Product)
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefault(x => x.OrderID == 10250);

        return list;
    }
}

public static class Helpers
{
    public static string Greeting(Customers customer) => customer switch
    {

        { CompanyName: "Pericles Comidas clÃ¡sicas", CountryIdentifierNavigation.Name: "Mexico" } => $"Hola {customer.Contact.FullName}",
        { CompanyName: "Alfreds Futterkiste", CountryIdentifierNavigation.Name: "Germany" } => $"Hallo {customer.Contact.FullName}",
        { CountryIdentifierNavigation.Name: "Italy" } => $"Ciao {customer.Contact.FullName}",
        _ => $"Hello {customer.Contact.FullName}"
    };


};

