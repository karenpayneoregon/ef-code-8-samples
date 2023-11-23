using System.Text;
using WineConsoleApp.Data;
using WineConsoleApp.Models;
using static WineConsoleApp.Classes.AnsiConsoleHelpers;

#pragma warning disable CS8602

namespace WineConsoleApp.Classes;

public class WineOperations
{
    public static void Indexing()
    {
        using WineContext context = new();
        var wines = context.Wines.ToList();

        var wineContainer = RangeHelpers.Get(wines);

        StringBuilder builder = new();

        foreach (var container in wineContainer)
        {
            builder.AppendLine($" {container.Value.Name,-25} " +
                               $"{container.Value.WineType,-7} " +
                               $"{container.StartIndex,-6} " +
                               $"{container.EndIndex,-7}" +
                               $"{container.MonthIndex}");
        }
        Console.WriteLine(" Wine                      Type    Start  End    Ordinal");
        Console.WriteLine("                                   range  range  index");
        Console.WriteLine(builder);

        Console.WriteLine();

        Index indexer = wineContainer
            .FindIndex(w => w.Value.Name == "Pinot Grigi");


        CyanMarkup("Last two wines");
        Range range = Range.StartAt(indexer);

        var lastTwoWines = wines.ToArray()[range];
        foreach (var wine in lastTwoWines)
        {
            Console.WriteLine(wine.Name);
        }

        Console.WriteLine();
        Console.WriteLine("First two wines");

        range = Range.EndAt(indexer);
        var firstTwoWines = wines.ToArray()[range];
        foreach (var wine in firstTwoWines)
        {
            Console.WriteLine(wine.Name);
        }

        Console.WriteLine();
    }

    public static void Run()
    {
        using WineContext context = new();


        CyanMarkup("Grouped");

        List<WineGroupItem> allWinesGrouped = context.Wines
            .GroupBy( wine => wine.WineType)
            .Select(wineGrouped => 
                new WineGroupItem(wineGrouped.Key, wineGrouped.ToList()))
            .ToList();

        foreach (WineGroupItem wineItem in allWinesGrouped)
        {
            Console.WriteLine(wineItem.Key);
            foreach (var wine in wineItem.List)
            {
                Console.WriteLine($"\t{wine.WineId, -5}{wine.Name}");
            }
        }

        Console.WriteLine();

        List<Wine> allWines = context.Wines.ToList();


        CyanMarkup("All");

        foreach (Wine wine in allWines)
        {
            Console.WriteLine($"{wine.WineType,-8}{wine.Name}");
        }

        Console.WriteLine();

        List<Wine> rose = context.Wines
            .Where(wine => wine.WineType == WineType.Rose)
            .ToList();

        CyanMarkup("Rose");

        if (rose.Count == 0)
        {
            Console.WriteLine("\tNone");
        }
        else
        {
            foreach (Wine roseWine in rose)
            {
                Console.WriteLine($"{roseWine.Name,30}");
            }
        }


        CyanMarkup("Red");

        List<Wine> redWines = context.Wines
            .Where(wine => wine.WineType == WineType.Red)
            .ToList();

        foreach (Wine wine in redWines)
        {
            Console.WriteLine($"{wine.Name,30}");
        }

    }
}