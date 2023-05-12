using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Place4AllBackend.Domain.Entities;
using Place4AllBackend.Infrastructure.Persistence;

namespace Place4AllBackend.Infrastructure.Seeders;

public class RestaurantSeeder
{
    public static async Task SeedSampleRestaurantsAsync(ApplicationDbContext context)
    {
        if (!context.Restaurants.Any())
        {
            
            //1 Restaurante: El Granero
            context.Restaurants.Add(new Restaurant()
            {
                Id = 1,
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
                Features = new List<Feature>(),
                Reviews = new List<Review>(),
            });

            //2 Restaurante: Sushi Kaiten
            context.Restaurants.Add(new Restaurant()
            {
                Id = 2,
                Name = "Sushi Kaiten",
                Address = new Address
                {
                    Street = "Calle de Isaac Peral",
                    Number = 2,
                    City = "Zaragoza",
                    ZipCode = "50014",
                    Province = "Zaragoza"
                },
                Description = "Sushi de alta calidad en un ambiente moderno y agradable.",
                PhoneNumber = "976123456",
                Images =
                {
                    new Image { Link = "@/assets/restaurantes/Sushi-Kaiten/sushi1.jpg" },
                    new Image { Link = "@/assets/restaurantes/Sushi-Kaiten/sushi2.jpeg" },
                    new Image { Link = "@/assets/restaurantes/Sushi-Kaiten/sushi3.jpg" }
                },
                Features = new List<Feature>(),
                Reviews = new List<Review>(),
            });

            //3 Restaurante: Le Bistrot Parisien
            context.Restaurants.Add(new Restaurant()
            {
                Id = 3,
                Name = "Le Bistrot Parisien",
                Address = new Address
                {
                    Street = "Calle de Fuencarral",
                    Number = 99,
                    City = "Madrid",
                    ZipCode = "28004",
                    Province = "Madrid"
                },
                Description = "Un pedazo de Francia en pleno centro de Madrid.",
                PhoneNumber = "910 11 22 33",
                Images =
                {
                    new Image { Link = "@/assets/restaurantes/Le-Bistrot-Parisien/bistro-frances1.jpg" },
                    new Image { Link = "@/assets/restaurantes/Le-Bistrot-Parisien/bistro-frances2.jpg" },
                    new Image { Link = "@/assets/restaurantes/Le-Bistrot-Parisien/bistro-frances3.jpg" }
                },
                Features = new List<Feature>(),
                Reviews = new List<Review>(),
            });

            //4 Restaurante: La Tagliatella
            context.Restaurants.Add(new Restaurant()
            {
                Id = 4,
                Name = "La Tagliatella",
                Address = new Address
                {
                    Street = "Calle del Coso",
                    Number = 86,
                    City = "Zaragoza",
                    ZipCode = "50001",
                    Province = "Zaragoza"
                },
                Description = "Auténtica comida italiana en un ambiente elegante.",
                PhoneNumber = "976123456",
                Images =
                {
                    new Image { Link = "@/assets/restaurantes/La-Tagliatella/tagliatella1.jpg" },
                    new Image { Link = "@/assets/restaurantes/La-Tagliatella/tagliatella2.jpg" },
                    new Image { Link = "@/assets/restaurantes/La-Tagliatella/tagliatella3.jpg" }
                },
                Features = new List<Feature>(),
                Reviews = new List<Review>(),
            });

            //5 La Taberna del Mar
            context.Restaurants.Add(new Restaurant()
            {
                Id = 5,
                Name = "La Taberna del Mar",
                Address = new Address
                {
                    Street = "Calle de la Reina",
                    Number = 13,
                    City = "Valencia",
                    ZipCode = "46011",
                    Province = "Valencia"
                },
                Description = "Bar de ambiente amigable para disfrutar de tapas de pescado y marisco frescos.",
                PhoneNumber = "961234567",
                Images =
                {
                    new Image { Link = "@/assets/restaurantes/La-Taberna-del-Mar/taberna1.jpg" },
                    new Image { Link = "@/assets/restaurantes/La-Taberna-del-Mar/taberna2.jpeg" },
                    new Image { Link = "@/assets/restaurantes/La-Taberna-del-Mar/taberna3.jpg" }
                },
                Features = new List<Feature>(),
                Reviews = new List<Review>(),
            });

            //6 La Parrilla de Juan
            context.Restaurants.Add(new Restaurant()
            {
                Id = 6,
                Name = "La Parrilla de Juan",
                Address = new Address
                {
                    Street = "Calle del Temple",
                    Number = 4,
                    City = "Zaragoza",
                    ZipCode = "50003",
                    Province = "Zaragoza"
                },
                Description = "Asador argentino con platos de carne de excelente calidad",
                PhoneNumber = "976654321",
                Images =
                {
                    new Image { Link = "@/assets/restaurantes/La-Parrilla-de-Juan/argentino1.jpg" },
                    new Image { Link = "@/assets/restaurantes/La-Parrilla-de-Juan/argentino2.jpg" },
                    new Image { Link = "@/assets/restaurantes/La-Parrilla-de-Juan/argentino3.jpg" }
                },
                Features = new List<Feature>(),
                Reviews = new List<Review>(),
            });
            
            //7 La Mamma
            context.Restaurants.Add(new Restaurant()
            {
                Id = 7,
                Name = "La Mamma",
                Address = new Address
                {
                    Street = "Calle San Juan de la Cruz",
                    Number = 16,
                    City = "Zaragoza",
                    ZipCode = "50006",
                    Province = "Zaragoza"
                },
                Description = "Franquicia con auténtica comida italiana.",
                PhoneNumber = "976654321",
                Images =
                {
                    new Image { Link = "@/assets/restaurantes/La-Mamma/paris-italiano1.jpg" },
                    new Image { Link = "@/assets/restaurantes/La-Mamma/paris-italiano2.jpg" },
                    new Image { Link = "@/assets/restaurantes/La-Mamma/paris-italiano3.jpg" }
                },
                Features = new List<Feature>(),
                Reviews = new List<Review>(),
            });

            //8 La Casa del Tenedor
            context.Restaurants.Add(new Restaurant()
            {
                Id = 8,
                Name = "La Casa del Tenedor",
                Address = new Address
                {
                    Street = "Calle del Duque de Sesto",
                    Number = 48,
                    City = "Madrid",
                    ZipCode = "28009",
                    Province = "Madrid"
                },
                Description = "Restaurante de cocina fusión mediterránea y asiática, una explosión de sabores en tu paladar",
                PhoneNumber = "+34 911 23 45 67",
                Images =
                {
                    new Image { Link = "@/assets/restaurantes/La-Casa-del-Tenedor/tenedor1.jpg" },
                    new Image { Link = "@/assets/restaurantes/La-Casa-del-Tenedor/tenedor2.jpg" },
                    new Image { Link = "@/assets/restaurantes/La-Casa-del-Tenedor/tenedor3.jpg" }
                },
                Features = new List<Feature>(),
                Reviews = new List<Review>(),
            });

            //9 El Sabor de México
            context.Restaurants.Add(new Restaurant()
            {
                Id = 9,
                Name = "El Sabor de México",
                Address = new Address
                {
                    Street = "Calle del Coso",
                    Number = 88,
                    City = "Zaragoza",
                    ZipCode = "50001",
                    Province = "Zaragoza"
                },
                Description = "Deliciosos platos de comida rápida mexicana en un ambiente acogedor.",
                PhoneNumber = "976654321",
                Images =
                {
                    new Image { Link = "@/assets/restaurantes/El-Sabor-de-Mexico/mexicano1.jpg" },
                    new Image { Link = "@/assets/restaurantes/El-Sabor-de-Mexico/mexicano2.jpg" },
                    new Image { Link = "@/assets/restaurantes/El-Sabor-de-Mexico/mexicano3.jpg" }
                },
                Features = new List<Feature>(),
                Reviews = new List<Review>(),
            });

            //10 El Farolito
            context.Restaurants.Add(new Restaurant()
            {
                Id = 10,
                Name = "El Farolito",
                Address = new Address
                {
                    Street = "Calle de las Huertas",
                    Number = 27,
                    City = "Madrid",
                    ZipCode = "28012",
                    Province = "Madrid"
                },
                Description = "Bar de tapas con auténtico sabor andaluz en pleno centro de Madrid.",
                PhoneNumber = "911111111",
                Images =
                {
                    new Image { Link = "@/assets/restaurantes/El-Farolito/madrid1.jpg" },
                    new Image { Link = "@/assets/restaurantes/El-Farolito/madrid2.jpg" },
                    new Image { Link = "@/assets/restaurantes/El-Farolito/madrid3.jpg" }
                },
                Features = new List<Feature>(),
                Reviews = new List<Review>(),
            });

            //11 El Cangrejo Loco
            context.Restaurants.Add(new Restaurant()
            {
                Id = 11,
                Name = "El Cangrejo Loco",
                Address = new Address
                {
                    Street = "Avenida de Ranillas",
                    Number = 25,
                    City = "Zaragoza",
                    ZipCode = "50018",
                    Province = "Zaragoza"
                },
                Description = "Restaurante familiar con amplios espacios y gran variedad de platos para todos los gustos.",
                PhoneNumber = "976987654",
                Images =
                {
                    new Image { Link = "@/assets/restaurantes/El-Cangrejo-Loco/mariscos1.jpg" },
                    new Image { Link = "@/assets/restaurantes/El-Cangrejo-Loco/mariscos.jpg" },
                    new Image { Link = "@/assets/restaurantes/El-Cangrejo-Loco/mariscos3.jpg" }
                },
                Features = new List<Feature>(),
                Reviews = new List<Review>(),
            });

            //12
            var restaurant = new Restaurant()
            {
                Id = 12,
                Name = "El Bistro de la Abuela",
                Address = new Address
                {
                    Street = "Calle de San Miguel",
                    Number = 34,
                    City = "Zaragoza",
                    ZipCode = "50001",
                    Province = "Zaragoza"
                },
                Description = "Restaurante familiar con ambiente acogedor y platos caseros.",
                PhoneNumber = "976654321",
                Images =
                {
                    new Image { Link = "@/assets/restaurantes/El-Bistro-de-la-Abuela/paris-bistro1.jpg" },
                    new Image { Link = "@/assets/restaurantes/El-Bistro-de-la-Abuela/paris-bistro2.jpg" },
                    new Image { Link = "@/assets/restaurantes/El-Bistro-de-la-Abuela/paris-bistro3.jpg" }
                },
                Features = new List<Feature>(),
                Reviews = new List<Review>(),
            };

            await context.SaveChangesAsync();
        }
    }
}