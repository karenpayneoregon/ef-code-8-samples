﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using ChinookLoggingSample.Data;
using ChinookLoggingSample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace ChinookLoggingSample.Data.Configurations
{
    public partial class MediaTypeConfiguration : IEntityTypeConfiguration<MediaType>
    {
        public void Configure(EntityTypeBuilder<MediaType> entity)
        {
            entity.Property(e => e.Name).HasMaxLength(120);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<MediaType> entity);
    }
}
