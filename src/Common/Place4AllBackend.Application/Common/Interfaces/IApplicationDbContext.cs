using System.Threading;
using System.Threading.Tasks;
using Place4AllBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Place4AllBackendAyti.Domain.Entities;

namespace Place4AllBackend.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<City> Cities { get; set; }

        DbSet<District> Districts { get; set; }

        DbSet<Village> Villages { get; set; }
        DbSet<Restaurant> Restaurants { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<Feature> Features { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}