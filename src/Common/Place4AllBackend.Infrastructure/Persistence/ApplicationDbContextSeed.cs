using System.Linq;
using System.Threading.Tasks;
using Place4AllBackend.Infrastructure.Identity;
using Place4AllBackend.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Place4AllBackend.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var defaultUser = new ApplicationUser { UserName = "iayti", Email = "test@test.com" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Matech_1850");
                await userManager.AddToRolesAsync(defaultUser, new[] { administratorRole.Name });
            }
        }

        public static async Task SeedSampleCityDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.Cities.Any())
            {
                context.Cities.Add(new City
                {
                    Name = "Bursa",
                    Districts =
                    {
                        new District { Name = "Osmangazi" },
                        new District { Name = "Nilüfer" },
                        new District { Name = "Büyükorhan" },
                        new District { Name = "Yıldırım" },
                        new District { Name = "Gemlik" },
                        new District { Name = "Gürsu" },
                        new District { Name = "Harmancık" },
                        new District { Name = "İnegöl" },
                        new District { Name = "İznik" },
                        new District
                        {
                            Name = "Karacabey",
                            Villages =
                            {
                                new Village { Name = "Akçakoyun" },
                                new Village { Name = "Akçasusurluk" },
                                new Village { Name = "Akhisar" },
                                new Village { Name = "Arız" },
                                new Village { Name = "Bakırköy" },
                                new Village { Name = "Ballıkaya" },
                                new Village { Name = "Bayramdere" },
                                new Village { Name = "Beylik" },
                                new Village { Name = "Boğazköy" },
                                new Village { Name = "Çamlıca" },
                                new Village { Name = "Canbaz" },
                                new Village { Name = "Çarık" },
                                new Village { Name = "Çavuşköy" },
                                new Village { Name = "Çeşnigir" },
                                new Village { Name = "Dağesemen" },
                                new Village { Name = "Dağkadı" },
                                new Village { Name = "Danişment" },
                                new Village { Name = "Doğla" },
                                new Village { Name = "Ekinli" },
                                new Village { Name = "Ekmekçi" },
                                new Village { Name = "Eskikaraağaç" },
                                new Village { Name = "Eskisarıbey" },
                                new Village { Name = "Fevzipaşa" },
                                new Village { Name = "Gölecik" },
                                new Village { Name = "Gölkıyı" },
                                new Village { Name = "Gönü" },
                                new Village { Name = "Güngörmez" },
                                new Village { Name = "Hamidiye" },
                                new Village { Name = "Harmanlı" },
                                new Village { Name = "Hayırlar" },
                                new Village { Name = "Hotanlı" },
                                new Village { Name = "Hürriyet" },
                                new Village { Name = "İkizce" },
                                new Village { Name = "İnkaya" },
                                new Village { Name = "İsmetpaşa" },
                                new Village { Name = "Karakoca" },
                                new Village { Name = "Karasu" },
                                new Village { Name = "Kedikaya" },
                                new Village { Name = "Keşlik" },
                                new Village { Name = "Kıranlar" },
                                new Village { Name = "Küçükkaraağaç" },
                                new Village { Name = "Kulakpınar" },
                                new Village { Name = "Kurşunlu" },
                                new Village { Name = "Muratlı" },
                                new Village { Name = "Okçular" },
                                new Village { Name = "Örencik" },
                                new Village { Name = "Orhaniye" },
                                new Village { Name = "Ortasarıbey" },
                                new Village { Name = "Ovaesemen" },
                                new Village { Name = "Şahinköy" },
                                new Village { Name = "Şahmelek" },
                                new Village { Name = "Sazlıca" },
                                new Village { Name = "Seyran" },
                                new Village { Name = "Subaşı" },
                                new Village { Name = "Sultaniye" },
                                new Village { Name = "Taşlık" },
                                new Village { Name = "Taşpınar" },
                                new Village { Name = "Tophisar" },
                                new Village { Name = "Uluabat" },
                                new Village { Name = "Yarış" },
                                new Village { Name = "Yeni" },
                                new Village { Name = "Yenikaraağaç" },
                                new Village { Name = "Yenisarıbey" },
                                new Village { Name = "Yeşildere" },
                                new Village { Name = "Yolağzı" }
                            }
                        },
                        new District { Name = "Keles" },
                        new District { Name = "Kestel" },
                        new District { Name = "Mudanya" },
                        new District { Name = "Mustafakemalpaşa" },
                        new District { Name = "Orhaneli" },
                        new District { Name = "Orhangazi" },
                        new District { Name = "Yenişehir" }
                    }
                });

                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedSampleRestaurantsAsync(ApplicationDbContext context)
        {
            if (!context.Restaurants.Any())
            {
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
                    }
                });

                await context.SaveChangesAsync();
            }
        }
    }
}