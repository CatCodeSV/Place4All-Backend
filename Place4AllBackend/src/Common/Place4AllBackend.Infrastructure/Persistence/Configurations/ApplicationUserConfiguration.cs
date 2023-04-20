using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Place4AllBackend.Domain.Entities;
using Place4AllBackend.Infrastructure.Identity;

namespace Place4AllBackend.Infrastructure.Persistence.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasOne(x => x.Address).WithOne().HasForeignKey<ApplicationUser>(x => x.AddressId);
        //builder.HasMany(x => x.FavoriteRestaurants).WithMany(x => x.FavoriteUsers) TODO: El listado de usuarios en Restaurantes no es accesible
    }
}