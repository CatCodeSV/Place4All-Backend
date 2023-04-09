using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Infrastructure.Persistence.Configurations;

public class ImageConfiguration: IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasOne(i => i.Restaurant)
            .WithMany(r => r.Images)
            .HasForeignKey(i => i.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}