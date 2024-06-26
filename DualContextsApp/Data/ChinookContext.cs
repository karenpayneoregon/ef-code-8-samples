﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using static ConsoleConfigurationLibrary.Classes.AppConnections;
using DualContextsApp.ChinookModels;
using EntityCoreFileLogger;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DualContextsApp.Data;

public partial class ChinookContext : DbContext
{
    public ChinookContext()
    {
    }

    public ChinookContext(DbContextOptions<ChinookContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Album { get; set; }

    public virtual DbSet<Artist> Artist { get; set; }

    public virtual DbSet<Customer> Customer { get; set; }

    public virtual DbSet<Employee> Employee { get; set; }

    public virtual DbSet<Genre> Genre { get; set; }

    public virtual DbSet<Invoice> Invoice { get; set; }

    public virtual DbSet<InvoiceLine> InvoiceLine { get; set; }

    public virtual DbSet<MediaType> MediaType { get; set; }

    public virtual DbSet<Playlist> Playlist { get; set; }

    public virtual DbSet<Table_1> Table_1 { get; set; }

    public virtual DbSet<Track> Track { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(Instance.MainConnection)
            .EnableSensitiveDataLogging()
            .LogTo(new DbContextToFileLogger().Log, new[]
                {
                    DbLoggerCategory.Database.Command.Name
                },
                LogLevel.Information);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasIndex(e => e.ArtistId, "IFK_AlbumArtistId");

            entity.Property(e => e.AlbumId).HasComment("Primary key");
            entity.Property(e => e.ArtistId).HasComment("Identifier of artist to artist table");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(160)
                .HasComment("Title of album");

            entity.HasOne(d => d.Artist).WithMany(p => p.Album)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AlbumArtistId");
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.Property(e => e.ArtistId).HasComment("Primary key");
            entity.Property(e => e.Name)
                .HasMaxLength(120)
                .HasComment("Name of artist");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasIndex(e => e.SupportRepId, "IFK_CustomerSupportRepId");

            entity.Property(e => e.CustomerId).HasComment("Customer primary key");
            entity.Property(e => e.Address)
                .HasMaxLength(70)
                .HasComment("Street address");
            entity.Property(e => e.City)
                .HasMaxLength(40)
                .HasComment("City");
            entity.Property(e => e.Company)
                .HasMaxLength(80)
                .HasComment("Company");
            entity.Property(e => e.Country)
                .HasMaxLength(40)
                .HasComment("Country");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(60)
                .HasComment("Company email");
            entity.Property(e => e.Fax)
                .HasMaxLength(24)
                .HasComment("Customer's fax");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("First");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("Last");
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasComment("Customer phone");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasComment("Postal/Zip code");
            entity.Property(e => e.State)
                .HasMaxLength(40)
                .HasComment("US State");
            entity.Property(e => e.SupportRepId).HasComment("Representives key");

            entity.HasOne(d => d.SupportRep).WithMany(p => p.Customer)
                .HasForeignKey(d => d.SupportRepId)
                .HasConstraintName("FK_CustomerSupportRepId");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasIndex(e => e.ReportsTo, "IFK_EmployeeReportsTo");

            entity.Property(e => e.Address).HasMaxLength(70);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.City).HasMaxLength(40);
            entity.Property(e => e.Country).HasMaxLength(40);
            entity.Property(e => e.Email).HasMaxLength(60);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Phone).HasMaxLength(24);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.State).HasMaxLength(40);
            entity.Property(e => e.Title).HasMaxLength(30);

            entity.HasOne(d => d.ReportsToNavigation).WithMany(p => p.InverseReportsToNavigation)
                .HasForeignKey(d => d.ReportsTo)
                .HasConstraintName("FK_EmployeeReportsTo");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.Property(e => e.GenreId).HasComment("Genre primary key");
            entity.Property(e => e.Name)
                .HasMaxLength(120)
                .HasComment("Name");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IFK_InvoiceCustomerId");

            entity.Property(e => e.BillingAddress).HasMaxLength(70);
            entity.Property(e => e.BillingCity).HasMaxLength(40);
            entity.Property(e => e.BillingCountry).HasMaxLength(40);
            entity.Property(e => e.BillingPostalCode).HasMaxLength(10);
            entity.Property(e => e.BillingState).HasMaxLength(40);
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("numeric(10, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoice)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceCustomerId");
        });

        modelBuilder.Entity<InvoiceLine>(entity =>
        {
            entity.HasIndex(e => e.InvoiceId, "IFK_InvoiceLineInvoiceId");

            entity.HasIndex(e => e.TrackId, "IFK_InvoiceLineTrackId");

            entity.Property(e => e.UnitPrice).HasColumnType("numeric(10, 2)");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceLine)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceLineInvoiceId");

            entity.HasOne(d => d.Track).WithMany(p => p.InvoiceLine)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceLineTrackId");
        });

        modelBuilder.Entity<MediaType>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(120);
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.Property(e => e.PlaylistId).HasComment("Play list primary key");
            entity.Property(e => e.Name)
                .HasMaxLength(120)
                .HasComment("Play list name");

            entity.HasMany(d => d.Track).WithMany(p => p.Playlist)
                .UsingEntity<Dictionary<string, object>>(
                    "PlaylistTrack",
                    r => r.HasOne<Track>().WithMany()
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PlaylistTrackTrackId"),
                    l => l.HasOne<Playlist>().WithMany()
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PlaylistTrackPlaylistId"),
                    j =>
                    {
                        j.HasKey("PlaylistId", "TrackId").IsClustered(false);
                        j.HasIndex(new[] { "TrackId" }, "IFK_PlaylistTrackTrackId");
                    });
        });

        modelBuilder.Entity<Table_1>(entity =>
        {
            entity.Property(e => e.Bogus)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasIndex(e => e.AlbumId, "IFK_TrackAlbumId");

            entity.HasIndex(e => e.GenreId, "IFK_TrackGenreId");

            entity.HasIndex(e => e.MediaTypeId, "IFK_TrackMediaTypeId");

            entity.Property(e => e.TrackId).HasComment("Track idendifier");
            entity.Property(e => e.AlbumId).HasComment("Key to album");
            entity.Property(e => e.Bytes).HasComment("Bytes");
            entity.Property(e => e.Composer)
                .HasMaxLength(220)
                .HasComment("Composer");
            entity.Property(e => e.GenreId).HasComment("Genre key for track");
            entity.Property(e => e.MediaTypeId).HasComment("Type of media");
            entity.Property(e => e.Milliseconds).HasComment("Milliseconds play time");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasComment("Track name");
            entity.Property(e => e.UnitPrice)
                .HasComment("Price of track")
                .HasColumnType("numeric(10, 2)");

            entity.HasOne(d => d.Album).WithMany(p => p.Track)
                .HasForeignKey(d => d.AlbumId)
                .HasConstraintName("FK_TrackAlbumId");

            entity.HasOne(d => d.Genre).WithMany(p => p.Track)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK_TrackGenreId");

            entity.HasOne(d => d.MediaType).WithMany(p => p.Track)
                .HasForeignKey(d => d.MediaTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrackMediaTypeId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}