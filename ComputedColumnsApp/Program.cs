using ComputedColumnsApp.Classes;

namespace ComputedColumnsApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[yellow]Computed columns[/] [white]YearsOld,FullName,BirthYear[/]");

        Console.WriteLine();
        Operations.AllContacts();
        Console.WriteLine();

        Operations.ReadForRetirement();
        Console.WriteLine();

        Operations.FindByFullName();
        Console.WriteLine();

        Operations.ComputedProducts();


        Console.ReadLine();
    }


}