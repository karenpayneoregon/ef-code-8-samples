﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWind2024StarterApp.Data;
using System;
using System.Collections.Generic;
using DualContextsApp.NorthModels;

namespace NorthWind2024StarterApp.Data.Configurations
{
    public partial class ShipperConfiguration : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> entity)
        {
            entity.Property(e => e.ShipperId)
            .ValueGeneratedNever()
            .HasColumnName("ShipperID");
            entity.Property(e => e.CompanyName)
            .IsRequired()
            .HasMaxLength(40);
            entity.Property(e => e.Phone).HasMaxLength(24);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Shipper> entity);
    }
}
