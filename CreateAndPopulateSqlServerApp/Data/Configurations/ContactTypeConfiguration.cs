using CreateAndPopulateSqlServerApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreateAndPopulateSqlServerApp.Data.Configurations;

public partial class ContactTypeConfiguration : IEntityTypeConfiguration<ContactType>
{
    public void Configure(EntityTypeBuilder<ContactType> entity)
    {
        entity.HasKey(e => e.ContactTypeIdentifier);

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<ContactType> entity);
}