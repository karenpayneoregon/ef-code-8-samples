using ComputedColumnsApp.Data;
using ComputedColumnsApp.Models;
#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace ComputedColumnsApp.Classes;
internal class Operations
{
    public static void AllContacts()
    {
        AnsiConsole.MarkupLine("[cyan]All contacts[/]");
        using var context = new Context();
        var contacts = context.Contact.ToList();
        foreach (Contact item in contacts)
        {
            Console.WriteLine($"{item.Id,-3}{item.FullName,-15}Is {item.YearsOld,-3}years old born {item.BirthYear}");
        }

        Console.WriteLine();
    }

    public static void ReadForRetirement()
    {
        using var context = new Context();
        int yearsOld = 65;

        AnsiConsole.MarkupLine($"[cyan]Ready for retirement, age > [/][yellow]{yearsOld}[/]");
        var readyForRetirement = context.Contact.Where(contact => contact.YearsOld > yearsOld).ToList();

        foreach (Contact item in readyForRetirement)
        {
            Console.WriteLine($"{item.Id,-3}{item.FullName,-15}Is {item.YearsOld,-3}years old born {item.BirthYear}");
        }

        Console.WriteLine();
    }

    public static void FindByFullName()
    {
        AnsiConsole.MarkupLine("[cyan]Find by full name[/]");
        var fullName = "Karen Payne";
        using var context = new Context();
        var contact = context.Contact.FirstOrDefault(item => item.FullName == fullName);
        Console.WriteLine(contact.Id);
        Console.WriteLine();
    }

    public static void ComputedProducts()
    {
        AnsiConsole.MarkupLine("[cyan]Products price[/]");
        using var context = new Context();
        var list = context.Products.Take(5).ToList();

        foreach (var product in list)
        {
            /*
             * Price is a computed column of PriceRaw.
             * We could format via :C6 to get the same result as Price, but we are simply showing possibilities
             * with computed columns not formatting.
             */
            Console.WriteLine($"{product.Id,-3}{product.ProductName,-20}{product.PriceRaw,-15} {product.Price}");
        }


    }    
}
