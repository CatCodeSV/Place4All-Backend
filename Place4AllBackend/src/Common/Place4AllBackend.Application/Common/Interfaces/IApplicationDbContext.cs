using System.Threading;
using System.Threading.Tasks;
using Place4AllBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Place4AllBackend.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Restaurant> Restaurants { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<Feature> Features { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Reservation> Reservations { get; set; }
        DbSet<Review> Reviews { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}