using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace HasConversion_Bool_ColorApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
    private static Table CreateTable()
    {
        return new Table()
            .RoundedBorder().BorderColor(Color.LightSlateGrey)
            .AddColumn("[b]Id[/]")
            .AddColumn("[b]First[/]")
            .AddColumn("[b]Last[/]")
            .AddColumn("[b]Is-string[/]")
            .AddColumn("[b]Is-bool[/]")
            .AddColumn("[b]Color[/]")
            .AddColumn("[b]Born[/]")
            .Alignment(Justify.Center)
            .Title("[white on blue]Friends[/]");
    }
}
