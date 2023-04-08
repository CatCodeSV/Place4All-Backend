﻿using Place4AllBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Place4AllBackend.Infrastructure.Persistence.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}