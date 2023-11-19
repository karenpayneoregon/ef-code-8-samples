using BooksApp.Models;

namespace BooksApp.Classes;
public partial class BookOperations
{
    private static void GroupNoSwitchOutput(List<IGrouping<int, Book>> results)
    {
        AnsiConsole.MarkupLine("[b]Example [cyan]1[/][/]");
        foreach (var item in results)
        {
            Console.WriteLine(PriceRange()[item.Key]);
            foreach (var book in item)
            {
                Console.WriteLine($"\t{book.Title,-30}{book.Price:C}");
            }
        }
    }
    private static void GroupWithSwitchOutput(List<GroupSwitch> results)
    {
        AnsiConsole.MarkupLine("[b]Example [cyan]2[/][/]");
        foreach (var item in results)
        {
            Console.WriteLine(item.Category);
            foreach (var book in item.List)
            {
                Console.WriteLine($"\t{book.Title,-30}{book.Price:C}");
            }
        }
    }

    private static Dictionary<int, string> PriceRange()
        => new()
        {
            { 10, "Cheap" }, { 20, "Medium" }, { 30, "Expensive" }
        };
}
