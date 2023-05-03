using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Place4AllBackend.Domain.Entities;
using Place4AllBackend.Infrastructure.Persistence;

namespace Place4AllBackend.Infrastructure.Seeders;

public class RestaurantSeeder
{
    public static async Task SeedSampleRestaurantsAsync(ApplicationDbContext context)
    {
        if (!context.Restaurants.Any())
        {
            var userAlex = context.Users.FirstOrDefault(x => x.Email == "keevinaguirre@gmail.com");
            var userLaura = context.Users.FirstOrDefault(x => x.Email == "lauragilf.13@gmail.com");
            var userSandra = context.Users.FirstOrDefault(x => x.Email == "diazmalo@hotmail.com");
            context.Restaurants.Add(new Restaurant()
            {
                Name = "El Granero",
                Address = new Address
                {
                    Street = "Calle Bernardo",
                    Number = 120,
                    City = "Madrid",
                    ZipCode = "28015",
                    Province = "Madrid"
                },
                Description = "Comida tradicional española en un ambiente acogedor.",
                PhoneNumber = "911234567",
                Images =
                {
                    new Image { Link = "@/assets/restaurantes/El-Granero/spain1.jpg" },
                    new Image { Link = "@/assets/restaurantes/El-Granero/spain2.jpeg" },
                    new Image { Link = "@/assets/restaurantes/El-Granero/spain3.jpg" }
                },
                Features =
                {
                    new Feature
                    {
                        Name = "Acceso PMR",
                        Description = "Acceso al local adaptado para personas con movilidad reducida"
                    },
                    new Feature
                    {
                        Name = "Perro guía",
                        Description =
                            "Se permite la entrada de perros guía para acompañar a personas con discapacidad visual."
                    },
                    new Feature
                    {
                        Name = "Menú adaptado",
                        Description =
                            "Se ofrece menú adaptado para personas con alergias o intolerancias alimentarias y/o dietas especiales."
                    },
                    new Feature
                    {
                        Name = "Mesas adaptadas",
                        Description =
                            "El restaurante cuenta con mesas adaptadas para personas con discapacidad, como mesas a diferentes alturas o con espacio suficiente para sillas de ruedas."
                    },
                    new Feature
                    {
                        Name = "Baño adaptado",
                        Description =
                            "El baño del restaurante está adaptado para personas con discapacidad y cuenta con barras de apoyo, inodoro elevado y lavabo accesible."
                    }
                },
                Reviews =
                {
                    new Review()
                    {
                        Comment = "Excelente servicio! Definitivamente repetiré e iré con mis amigos",
                        Value = 5,
                        Creator = userAlex?.Id,
                        InformationAccuracy = InformationAccuracy.VeryGood
                    },
                    new Review()
                    {
                        Comment = "Estuvo muy bien, me hubiera gustado que tuviera más opciones vegetarianas",
                        Value = 3,
                        Creator = userLaura?.Id,
                        InformationAccuracy = InformationAccuracy.VeryGood,
                        RestaurantId = 1
                    },
                    new Review()
                    {
                        Comment = "Repetiré seguro, me encantó la comida y el servicio",
                        Value = 4,
                        Creator = userSandra?.Id,
                        InformationAccuracy = InformationAccuracy.Good,
                        RestaurantId = 1
                    }
                }
            });

            await context.SaveChangesAsync();
        }
    }
}