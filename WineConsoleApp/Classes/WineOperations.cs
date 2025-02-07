using System.Text;
using WineConsoleApp.Data;
using WineConsoleApp.Models;
using static Spectre.Console.AnsiConsole;
using static WineConsoleApp.Classes.AnsiConsoleHelpers;
using Console = System.Console;

#pragma warning disable CS8602

namespace WineConsoleApp.Classes;

public class WineOperations
{
    public static void MergeCases()
    {
        using WineContext context = new();
        var wines = context.Wines.ToList();

        foreach (var wine in wines)
        {
            switch (wine.WineType)
            {
                case WineType.Red:
                    PrintWine1(wine);
                    break;
                case WineType.Rose:
                    PrintWine1(wine);
                    break;
                case WineType.White:
                    PrintWine2(wine);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return;

        void PrintWine1(Wine wine) => MarkupLine($"{wine.WineId,-2}[red]{wine.Name}[/]");
        void PrintWine2(Wine wine) => MarkupLine($"{wine.WineId,-2}[white]{wine.Name}[/]");
    }

    
    public static void Indexing()
    {
        using WineContext context = new();
        var wines = context.Wines.ToList();

        var rose = wines.Where(w => w.WineType == WineType.Rose);

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

        

        /*
         * Example of iterate an enum
         */

        foreach (WineType wineType in (WineType[])Enum.GetValues(typeof(WineType)))
        {
            var wineTypeArray = wines.Where(w => w.WineType == wineType);
            MarkupLine($"[lightgreen_1]{wineType}[/]");
            foreach (var wine in wineTypeArray)
            {
                Console.WriteLine($"{wine.WineId,-2}{wine.Name}");
            }

            Console.WriteLine();
            
        }



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

        var parameterizedWineType = WineType.Rose;
        List<Wine> rose = context.Wines
            .Where(wine => wine.WineType == parameterizedWineType)
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