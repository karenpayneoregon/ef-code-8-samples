using AccessEntityFramework.Models;
using ConfigurationLibrary.Classes;
using Microsoft.EntityFrameworkCore;


namespace AccessEntityFramework.Data;

public class BookContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseJet(ConfigurationHelper.ConnectionString());
    }
}