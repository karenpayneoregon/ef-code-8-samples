using EF_Core_MaskingSample.Classes;
using EF_Core_MaskingSample.Data;

namespace EF_Core_MaskingSample;

internal partial class Program
{
    private static void Main(string[] args)
    {
        AnsiConsole.MarkupLine($"[{Color.Cyan1}]MaterializationInterceptionData[/]");
        Console.WriteLine();
        using var context = new Context();
        var person = context.Person.ToList();

        foreach (var p in person)
        {
            AnsiConsole.MarkupLine($"{p.Id,-5}{p.FirstName,-15}{p.LastName,-15}{p.SocialSecurity.Colorized1(),-25}{p.BirthDate,-12}{p.CreditCard.Colorized2()}");
        }

        Console.WriteLine();
        AnsiConsole.Markup($"[{Color.Cyan1}]Done[/]");

        Console.ReadLine();
    }
}
