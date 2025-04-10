using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelectiveUpdatesApp.Models;

namespace SelectiveUpdatesApp.Data.Configurations;

public partial class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void _Configure(EntityTypeBuilder<Person> entity)
    {
        entity.Property(e => e.BirthDate)
            .HasColumnType("date")
            .HasComment("Their birth date");

        entity.Property(e => e.FirstName)
            .HasComment("First name");

        entity.Property(e => e.LastName)
            .HasComment("last name");

        entity.Property(e => e.Title)
            .HasComment("Mr Miss Mrs");

        entity.Property(e => e.Id)
            .HasComment("Primary key");

        OnConfigurePartial(entity);
    }
    public void Configure(EntityTypeBuilder<Person> entity)
    {
        entity.Property(e => e.BirthDate)
            .HasColumnType("date")
            .HasComment("Their birth date");

        entity.Property(e => e.FirstName)
            .HasComment("First name");

        entity.Property(e => e.LastName)
            .HasComment("last name");

        entity.Property(e => e.Title)
            .HasComment("Mr Miss Mrs");

        entity.Property(e => e.Id)
            .HasComment("Primary key");

        entity.HasData(
            new Person
            {
                Id = 1,
                Title = "Mr",
                FirstName = "James",
                LastName = "Gallagher",
                BirthDate = new DateTime(1957, 8, 7)
            },
            new Person
            {
                Id = 2,
                Title = "Mrs",
                FirstName = "Kate",
                LastName = "Gallagher",
                BirthDate = new DateTime(1960, 5, 11)
            },
            new Person
            {
                Id = 3,
                Title = "Mr",
                FirstName = "Billy bob",
                LastName = "Smith",
                BirthDate = new DateTime(1989, 9, 23)
            },
            new Person
            {
                Id = 4,
                Title = "Ms",
                FirstName = "Laura",
                LastName = "Stewart",
                BirthDate = new DateTime(1993, 3, 15)
            },
            new Person
            {
                Id = 5,
                Title = "Dr",
                FirstName = "Henry",
                LastName = "Wells",
                BirthDate = new DateTime(1971, 11, 3)
            },
            new Person
            {
                Id = 6,
                Title = "Mr",
                FirstName = "George",
                LastName = "Benson",
                BirthDate = new DateTime(1985, 6, 20)
            }
        );

        OnConfigurePartial(entity);
    }


    partial void OnConfigurePartial(EntityTypeBuilder<Person> entity);
}