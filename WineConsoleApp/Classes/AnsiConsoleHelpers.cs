using Spectre.Console;

namespace WineConsoleApp.Classes;
public static class AnsiConsoleHelpers
{
    /// <summary>
    /// Write text with foreground color cyan
    /// </summary>
    /// <param name="text">What to display</param>
    public static void CyanMarkup(string text)
    {
        AnsiConsole.MarkupLine($"[cyan]{text}[/]");
    }
    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    public static void ExitPrompt()
    {
        Console.WriteLine();
        Render(new Rule($"[yellow]Press a key to exit the demo[/]").RuleStyle(Style.Parse("silver")).Centered());
        Console.ReadLine();
    }
    public static void Line()
    {
        Console.WriteLine();
        Render(new Rule($"[yellow]Indexing[/]").RuleStyle(Style.Parse("silver")).Centered());

    }
}
