using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Infrastructure.Persistence.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.Property(r => r.People)
            .HasMaxLength(20).IsRequired();
        builder.Property(r => r.SpecialInstructions)
            .HasMaxLength(150);
        builder.HasOne(r => r.Restaurant)
            .WithMany().HasForeignKey(r => r.RestaurantId);
        builder.HasMany(r => r.Features)
            .WithMany(f => f.Reservations)
            .UsingEntity(j => j.ToTable("ReservationFeature"));
    }
}