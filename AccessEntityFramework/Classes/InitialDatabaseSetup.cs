using System.Data.OleDb;
using AccessEntityFramework.Data;
using AccessEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessEntityFramework.Classes;
internal class InitialDatabaseSetup
{
    /// <summary>
    /// Create database and populate if the database does not exists
    /// </summary>
    /// <returns></returns>
    public static async Task Create()
    {
        await using var context = new BookContext();

        OleDbConnectionStringBuilder builder = new(context.Database.GetConnectionString());
        var fileName = builder.DataSource;

        if (File.Exists(fileName))
        {
            return;
        }

        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        context.Categories.Add(new Category()
        {
            Description = "Action"
        });
        context.Categories.Add(new Category()
        {
            Description = "Suspense & Thriller"
        });
        context.Categories.Add(new Category()
        {
            Description = "Fiction"
        });
        context.Categories.Add(new Category()
        {
            Description = "Learn C#"
        });
        context.Categories.Add(new Category()
        {
            Description = "EF Core 7"
        });

        await context.SaveChangesAsync();

        context.Books.Add(new Book()
        {
            Price = 12.50m, 
            Title = "EF Core 1", 
            CategoryId = 5
        });
        context.Books.Add(new Book()
        {
            Price = 26.96m, Title = 
                "The Exchange: After The Firm", 
            CategoryId = 2
        });
        context.Books.Add(new Book()
        {
            Price = 79.99m, 
            Title = "C# Vol 1", 
            CategoryId = 4
        });
        context.Books.Add(new Book()
        {
            Price = 14.99m, 
            Title = "The Manor House: A Novel", 
            CategoryId = 2
        });
        context.Books.Add(new Book()
        {
            Price = 27m, 
            Title = "The Wager: A Tale of Shipwreck, Mutiny and Murder", 
            CategoryId = 3
        });

        await context.SaveChangesAsync();
    }
}
