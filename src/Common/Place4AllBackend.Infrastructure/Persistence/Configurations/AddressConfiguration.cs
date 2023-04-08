using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Place4AllBackendAyti.Domain.Entities;

namespace Place4AllBackend.Infrastructure.Persistence.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{

    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(t => t.City).IsRequired();
        builder.Property(t => t.Street).IsRequired();
        builder.Property(t => t.Number).IsRequired();
    }
}