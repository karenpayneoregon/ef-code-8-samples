using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace GetWeekendDatesCorrectlyAppCore;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        Console.WriteLine();
    }
    public static Table CreateOrderTable(string title)
    {
        var table = new Table()
            .RoundedBorder()
            .AddColumn("[cyan]Id[/]")
            .AddColumn("[cyan]Ordered[/]")
            .AddColumn("[cyan]Delivered[/]")
            .Alignment(Justify.Center)
            .BorderColor(Color.LightSlateGrey)
            .Title($"[LightGreen]{title}[/]");
        return table;
    }

    public static Table CreateGroupTable(string title = "Grouped")
    {
        var table = new Table()
            .RoundedBorder()
            .AddColumn("[cyan]Id[/]")
            .AddColumn("[cyan]Delivered[/]")
            .Alignment(Justify.Center)
            .BorderColor(Color.LightSlateGrey)
            .Title($"[LightGreen]{title}[/]");
        return table;
    }

}