using Microsoft.EntityFrameworkCore;
using ShadowProperties.Interfaces;


// ReSharper disable once CheckNamespace
namespace ShadowProperties.Data;
public partial class ShadowContext
{

    // un-comment to scaffold a page
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer(
    //        """
    //           Server=(localdb)\\mssqllocaldb;Database=EF.ShadowEntityCore;Trusted_Connection=True
    //           """);

    private void HandleChanges()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            // take care of date time created and updated
            if (entry.State is EntityState.Added or EntityState.Modified)
            {
                entry.Property("LastUpdated").CurrentValue = DateTime.Now;
                entry.Property("LastUser").CurrentValue = Environment.UserName;

                if (entry.Entity is IShadows && entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                    entry.Property("CreatedBy").CurrentValue = Environment.UserName;
                }
            }
            else if (entry.State == EntityState.Deleted)
            {
                // Change state to modified and set delete flag
                entry.State = EntityState.Modified;
                entry.Property("isDeleted").CurrentValue = true;
            }
        }
    }
}
