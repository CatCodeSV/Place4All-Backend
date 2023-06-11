using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Infrastructure.Persistence.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasOne(x => x.Address).WithOne().HasForeignKey<ApplicationUser>(x => x.AddressId);
        builder.HasMany(x => x.FavoriteRestaurants).WithMany(x => x.FavoriteUsers)
            .UsingEntity(j =>
                j.ToTable("FavoriteRestaurants"));
    }
}