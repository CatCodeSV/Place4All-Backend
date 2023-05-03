using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Place4AllBackend.Domain.Entities;
using Place4AllBackend.Infrastructure.Persistence;

namespace Place4AllBackend.Infrastructure.Seeders;

public class ReviewSeeder
{
    public static async Task SeedSampleReviews(ApplicationDbContext context)
    {
        if (!context.Reviews.Any())
        {
            context.Reviews.Add(new Review()
            {
                Comment = "Excelente servicio! Definitivamente repetiré e iré con mis amigos",
                Value = 5,
                Creator = context.Users.FirstOrDefault(x => x.Email == "keevinaguirre@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.VeryGood,
                RestaurantId = 1
            });
            await context.SaveChangesAsync();
        }
    }
}