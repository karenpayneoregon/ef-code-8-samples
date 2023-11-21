using CreateAndPopulateSqlServerApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreateAndPopulateSqlServerApp.Data.Configurations
{
    public partial class ContactsConfiguration : IEntityTypeConfiguration<Contacts>
    {
        public void Configure(EntityTypeBuilder<Contacts> entity)
        {
            // indicate that ContactId is the primary key
            entity.HasKey(e => e.ContactId);

            // indicate an index into child table ContactTypes
            entity.HasIndex(e => e.ContactTypeIdentifier, "IX_Contacts_ContactTypeIdentifier");

            // indicate there is one contact type per contact, many contacts to contact type.
            // indicate the foreign key into contacts table
            // put a check constraint on the foreign key
            entity.HasOne(d => d.ContactTypeNavigation)
                .WithMany(p => p.Contacts)
                .HasForeignKey(d => d.ContactTypeIdentifier)
                .HasConstraintName("FK_Contacts_ContactType");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Contacts> entity);
    }
}
