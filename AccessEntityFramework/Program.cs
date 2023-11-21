using AccessEntityFramework.Classes;
using AccessEntityFramework.Data;
using Microsoft.EntityFrameworkCore;

namespace AccessEntityFramework;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await InitialDatabaseSetup.Create();
        await using var context = new BookContext();

        // update example
        var theManorHouseBook = await context.Books.FirstOrDefaultAsync(b => b.Title == "The Manor House: A Novel");
        theManorHouseBook.Price += 1;

        await context.SaveChangesAsync();

        var books = context.Books
            .Include(b => b.Category)
            .OrderBy(b => b.Category.Description)
            .ToList();

        AnsiConsole.MarkupLine("[cyan]All books[/]");

        foreach (var book in books)
        {
            Console.WriteLine($"{book.Id, -3}{book.Title.Ellipsis(60)}" +
                              $"{book.Price,-8:C}{book.Category.Description}");
        }

        AnsiConsole.MarkupLine("[cyan]All Suspense & Thriller books[/]");
        books = context
            .Books
            .Include(b => b.Category)
            .Where(b => b.CategoryId == 2).ToList();

       
        foreach (var book in books)
        {
            Console.WriteLine($"{book.Id, -3}{book.Title.Ellipsis(60)}" +
                              $"{book.Price,-8:C}{book.Category.Description}");
        }


        AnsiConsole.MarkupLine("[cyan]Done[/]");
        SpectreConsoleHelpers.ExitPrompt();
    }
}