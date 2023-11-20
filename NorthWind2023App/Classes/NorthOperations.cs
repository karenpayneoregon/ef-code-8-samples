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
}
