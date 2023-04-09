using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Infrastructure.Persistence.Configurations;

public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
{
    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        builder.Property(t => t.Name).IsRequired();
        builder.Property(t => t.Description).IsRequired();
    }
}