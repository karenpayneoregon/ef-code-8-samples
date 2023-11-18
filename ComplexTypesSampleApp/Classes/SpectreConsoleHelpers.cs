namespace ComplexTypesSampleApp.Classes;
public class SpectreConsoleHelpers
{
    public static void ExitPrompt()
    {
        Console.WriteLine();

        Render(new Rule($"[yellow]Press[/] [cyan]ENTER[/] [yellow]to exit the demo[/]")
            .RuleStyle(Style.Parse("silver")).Centered());

        Console.ReadLine();
    }
    public static void PrintCyan([CallerMemberName] string? methodName = null)
    {
        AnsiConsole.MarkupLine($"[white]Running [/][cyan]{methodName}[/]");
        Console.WriteLine();
    }

    public static void RunningMessage(string message)
    {
        AnsiConsole.MarkupLine($"  [springgreen3_1]{message}[/]");
    }
    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }
}
