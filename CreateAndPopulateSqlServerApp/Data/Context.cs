using CreateAndPopulateSqlServerApp.Classes;
using Microsoft.EntityFrameworkCore;
using CreateAndPopulateSqlServerApp.Models;

namespace CreateAndPopulateSqlServerApp.Data
{
    internal partial class Context : DbContext
    {
        public virtual DbSet<ContactType> ContactType { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                ConnectionHelpers.StandardLoggingSqlServer(optionsBuilder);

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.ContactsConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ContactTypeConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}
