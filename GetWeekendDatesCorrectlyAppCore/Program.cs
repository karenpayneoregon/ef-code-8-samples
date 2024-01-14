using GetWeekendDatesCorrectlyAppCore.Classes;
using GetWeekendDatesCorrectlyAppCore.Data;
using GetWeekendDatesCorrectlyAppCore.Models;

namespace GetWeekendDatesCorrectlyAppCore;

internal partial class Program
{
    static void Main(string[] args)
    {
        using var context = new StoreContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var saturdayOrSundayDelivered = context
            .Orders
            .AsEnumerable()
            .Where(o => o.DeliveredDate.IsWeekend())
            .ToList();
            
        var weekEndTable = CreateOrderTable("Weekend");
        foreach (var order in saturdayOrSundayDelivered)
        {
            weekEndTable.AddRow(
                order.Id.ToString(), 
                order.OrderDate.ToShortDateString(), 
                order.DeliveredDate.ToString("yyyy-M-d dddd"));
        }

        AnsiConsole.Write(weekEndTable);
        Console.WriteLine();

        var weekDayTable = CreateOrderTable("Weekday");
        var weekdayDeliveries = 
            context.Orders.AsEnumerable().Where(o => !o.DeliveredDate.IsWeekend()).ToList();

        foreach (var order in weekdayDeliveries)
        {
            weekDayTable.AddRow(
                order.Id.ToString(), 
                order.OrderDate.ToShortDateString(), 
                order.DeliveredDate.ToString("yyyy-M-d dddd"));
        }

        AnsiConsole.Write(weekDayTable);
            
        Console.WriteLine();

        var groupWeek = context.Orders
            .AsEnumerable()
            .GroupBy(x => x.DeliveredDate.DayOfWeek)
            .Where(x => x.Key.IsWeekDay())
            .ToList();

        var groupWeekend1 = context.Orders
            .AsEnumerable()
            .GroupBy(o => o.DeliveredDate.DayOfWeek)
            .Where(o => o.Key.IsWeekend())
            .ToList();


        var groupWeekend2 = context.Orders
            .AsEnumerable()
            .GroupBy(o => o.DeliveredDate.DayOfWeek)
            .Select(o => new ItemContainer(o.Key, o.ToList()))
            .OrderBy(x => x.DayOfWeek)
            .ToList();

        var groupedTable = CreateGroupTable();
        foreach (var grouped in groupWeekend2)
        {
            groupedTable.AddRow(grouped.DayOfWeek.ToString());
            foreach (var order in grouped.List)
            {
                groupedTable.AddRow(order.Id.ToString(), order.DeliveredDate.ToShortDateString());
            }
        }

        AnsiConsole.Write(groupedTable);

        Console.ReadLine();
    }
}