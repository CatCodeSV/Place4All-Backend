using Place4AllBackend.Domain.Entities;
using Place4AllBackend.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Place4AllBackend.Infrastructure.Seeders
{
    public class RestaurantsFeaturesSeeder
    {
        public static async Task SeedSampleRestaurantsFeatures(ApplicationDbContext context)
        {

            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 1,
                FeaturesId = 1,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 1,
                FeaturesId = 1,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 1,
                FeaturesId = 2,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 1,
                FeaturesId = 3,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 1,
                FeaturesId = 4,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 2,
                FeaturesId = 1,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 2,
                FeaturesId = 2,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 2,
                FeaturesId = 3,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 2,
                FeaturesId = 4,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 2,
                FeaturesId = 5,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 2,
                FeaturesId = 6,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 2,
                FeaturesId = 7,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 3,
                FeaturesId = 2,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 3,
                FeaturesId = 5,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 3,
                FeaturesId = 10,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 4,
                FeaturesId = 1,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 4,
                FeaturesId = 3,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 4,
                FeaturesId = 4,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 4,
                FeaturesId = 8,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 4,
                FeaturesId = 10,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 4,
                FeaturesId = 11,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 5,
                FeaturesId = 2,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 5,
                FeaturesId = 5,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 5,
                FeaturesId = 12,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 5,
                FeaturesId = 13,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 6,
                FeaturesId = 1,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 6,
                FeaturesId = 3,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 6,
                FeaturesId = 4,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 6,
                FeaturesId = 8,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 6,
                FeaturesId = 10,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 7,
                FeaturesId = 5,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 7,
                FeaturesId = 11,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 8,
                FeaturesId = 1,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 8,
                FeaturesId = 5,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 8,
                FeaturesId = 10,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 8,
                FeaturesId = 11,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 8,
                FeaturesId = 14,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 9,
                FeaturesId = 8,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 10,
                FeaturesId = 9,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 11,
                FeaturesId = 1,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 11,
                FeaturesId = 3,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 11,
                FeaturesId = 4,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 11,
                FeaturesId = 10,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 11,
                FeaturesId = 11,
            });
            context.RestaurantsFeatures.Add(new RestaurantsFeatures()
            {
                RestaurantsId = 12,
                FeaturesId = 1,
            });
        }
    }
}
