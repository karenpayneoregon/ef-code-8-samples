using Microsoft.EntityFrameworkCore;
using ShadowProperties.Models;

namespace ShadowProperties.Data;

public partial class ShadowContext : DbContext
{
    public ShadowContext()
    {
        
    }
    public ShadowContext(DbContextOptions<ShadowContext> options) : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Contact>().Property<DateTime?>("LastUpdated");
        modelBuilder.Entity<Contact>().Property<string>("LastUser");
        modelBuilder.Entity<Contact>().Property<DateTime?>("CreatedAt");
        modelBuilder.Entity<Contact>().Property<string>("CreatedBy");
        modelBuilder.Entity<Contact>().Property<bool>("isDeleted");

        modelBuilder.Entity<Contact>(entity => entity.HasKey(e => e.ContactId));

        /*
         * Setup filter on Contact model to show only active records.
         * Since IsDeleted is not in the model the string name is used.
         */
        modelBuilder.Entity<Contact>()
            .HasQueryFilter(contact =>
                EF.Property<bool>(contact, "isDeleted") == false);

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new ())
    {
        HandleChanges();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        HandleChanges();
        return base.SaveChanges();
    }



    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}