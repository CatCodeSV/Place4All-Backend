using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Infrastructure.Persistence.Configurations;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(200)
            .IsRequired();
        builder.HasOne(r => r.Address)
            .WithOne()
            .HasForeignKey<Restaurant>(r => r.AddressId);
        builder.HasMany(r => r.Features)
            .WithMany(f => f.Restaurants)
            .UsingEntity(j => j.ToTable("RestaurantFeature"));
        builder.HasMany(r => r.Images)
            .WithOne(i => i.Restaurant);
        builder.HasMany(r => r.Reviews).WithOne().HasForeignKey(r => r.RestaurantId);
    }
}