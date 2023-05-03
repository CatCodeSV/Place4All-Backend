using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Infrastructure.Persistence.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.Property(x => x.Value).IsRequired();
        builder.Property(x => x.InformationAccuracy).IsRequired();
        builder.HasMany(x => x.AdditionalFeatures).WithMany(x => x.Reviews)
            .UsingEntity(j => j.ToTable("ReviewFeature"));
        builder.HasOne(i => i.Restaurant)
            .WithMany(r => r.Reviews)
            .HasForeignKey(i => i.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}