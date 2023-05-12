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
            var userAlex = context.Users.FirstOrDefault(x => x.Email == "keevinaguirre@gmail.com");
            var userLaura = context.Users.FirstOrDefault(x => x.Email == "lauragilf.13@gmail.com");
            var userSandra = context.Users.FirstOrDefault(x => x.Email == "diazmalo@hotmail.com");
            
            //1 Restaurante: El Granero
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
                }
            });

            //2 Restaurante: Sushi Kaiten
            context.Restaurants.Add(new Restaurant()
            {
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
                            "Se permite la entrada de perros guía para acompañar a personas con discapacidad visual"
                    },
                    new Feature
                    {
                        Name = "Menú Vegetariano",
                        Description = "Se ofrecen opciones vegetarianas en la carta"
                    },
                    new Feature
                    {
                        Name = "Menú Vegano",
                        Description = "Se ofrecen opciones veganas en la carta"
                    },
                    new Feature
                    {
                        Name = "Menú Sin Lactosa",
                        Description = "Todos los platos con lácteos y derivados se realizan con leche sin lactosa"
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
                }
            });

            //3 Restaurante: Le Bistrot Parisien
            context.Restaurants.Add(new Restaurant()
            {
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
                Features =
                {
                    new Feature
                    {
                        Name = "Terraza",
                        Description =
                            "Disfruta de tu comida al aire libre en nuestra terraza durante los días de buen tiempo."
                    },
                    new Feature
                    {
                        Name = "Menu Vegetariano",
                        Description =
                            "Se ofrecen opciones vegetarianas en la carta."
                    },
                    new Feature
                    {
                        Name = "Perro guía",
                        Description =
                            "Se permite la entrada de perros guía para acompañar a personas con discapacidad visual."
                    }
                },
                Reviews =
                {
                }
            });

            //4 Restaurante: La Tagliatella
            context.Restaurants.Add(new Restaurant()
            {
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
                Features =
                {
                    new Feature
                    {
                        Name = "Acceso PMR",
                        Description = "Acceso al local adaptado para personas con movilidad reducida"
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
                    },
                    new Feature
                    {
                        Name = "Terraza",
                        Description =
                            "El restaurante cuenta con una agradable terraza exterior donde se puede disfrutar de la comida al aire libre."
                    },
                    new Feature
                    {
                        Name = "Menú sin gluten",
                        Description =
                            "Se ofrece una amplia variedad de platos sin gluten para las personas con intolerancia o alergia al gluten."
                    },
                    new Feature
                    {
                        Name = "Aparcamiento",
                        Description =
                            "El restaurante cuenta con un amplio aparcamiento para la comodidad de los clientes."
                    }
                },
                Reviews =
                {
                }
            });

            //5 La Taberna del Mar
            context.Restaurants.Add(new Restaurant()
            {
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
                Features =
                {
                    new Feature
                    {
                        Name = "Carta en braile",
                        Description = "Se dispone de una carta en braile y de un código QR para disponer de la carta online con lectura automática"
                    },
                    new Feature
                    {
                        Name = "Intérprete Signos",
                        Description = "El personal del local sabe interpretar y comunicarse mediante el lenguaje de signos"
                    },
                    new Feature
                    {
                        Name = "Perro guía",
                        Description =
                            "Se permite la entrada de perros guía para acompañar a personas con discapacidad visual."
                    },
                    new Feature
                    {
                        Name = "Menu Vegetariano",
                        Description =
                            "Se ofrecen opciones vegetarianas en la carta."
                    }
                },
                Reviews =
                {
                }
            });

            //6 La Parrilla de Juan
            context.Restaurants.Add(new Restaurant()
            {
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
                Features =
                {
                    new Feature
                    {
                        Name = "Acceso PMR",
                        Description = "Acceso al local adaptado para personas con movilidad reducida"
                    },
                    new Feature
                    {
                        Name = "Terraza",
                        Description =
                            "El restaurante cuenta con una acogedora terraza exterior donde se puede disfrutar de la comida al aire libre."
                    },
                    new Feature
                    {
                        Name = "Menú sin gluten",
                        Description =
                            "Se ofrece una amplia variedad de platos sin gluten para las personas con intolerancia o alergia al gluten."
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
                }
            });
            
            //7 La Mamma
            context.Restaurants.Add(new Restaurant()
            {
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
                Features =
                {
                    new Feature
                    {
                        Name = "Menú vegetariano",
                        Description =
                            "La Mamma cuenta con una amplia variedad de opciones vegetarianas para aquellos que buscan una dieta más saludable y respetuosa con el medio ambiente."
                    },
                    new Feature
                    {
                        Name = "Aparcamiento",
                        Description =
                            "El restaurante cuenta con un aparcamiento cercano para la comodidad de los clientes."
                    }
                },
                Reviews =
                {
                }
            });

            //8 La Casa del Tenedor
            context.Restaurants.Add(new Restaurant()
            {
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
                Features =
                {
                    new Feature
                    {
                        Name = "Acceso PMR",
                        Description = "Acceso al local adaptado para personas con movilidad reducida"
                    },
                    new Feature
                    {
                        Name = "Terraza",
                        Description = "El restaurante cuenta con una terraza exterior con vistas a la ciudad."
                    },
                    new Feature
                    {
                        Name = "Menú vegetariano",
                        Description = "Se ofrece una amplia variedad de platos vegetarianos."
                    },
                    new Feature
                    {
                        Name = "Menú degustación",
                        Description = "Opción de menú degustación para experimentar una variedad de platos."
                    },
                    new Feature
                    {
                        Name = "Aparcamiento",
                        Description =
                            "El restaurante cuenta con un amplio aparcamiento para la comodidad de los clientes."
                    },
                    new Feature
                    {
                        Name = "Aparcacoches",
                        Description = "El restaurante cuenta con servicio de aparcacoches para la comodidad de los clientes."
                    }
                },
                Reviews =
                {
                }
            });

            //9 El Sabor de México
            context.Restaurants.Add(new Restaurant()
            {
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
                Features =
                {
                    new Feature
                    {
                        Name = "Menú sin gluten",
                        Description =
                            "Se ofrecen opciones de comida sin gluten para las personas con intolerancia o alergia al gluten."
                    }
                },
                Reviews =
                {
                }
            });

            //10 El Farolito
            context.Restaurants.Add(new Restaurant()
            {
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
                Features =
                {
                    new Feature
                    {
                        Name = "Menú Alérgenos",
                        Description =
                            "El restaurante cuenta con un menú con información de los posibles alérgenos"
                    }
                },
                Reviews =
                {
                }
            });

            //11 El Cangrejo Loco
            context.Restaurants.Add(new Restaurant()
            {
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
                Features =
                {
                    new Feature
                    {
                        Name = "Acceso PMR",
                        Description = "Acceso al local adaptado para personas con movilidad reducida"
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
                    },
                    new Feature
                    {
                        Name = "Terraza",
                        Description =
                            "El restaurante cuenta con una amplia terraza exterior donde se puede disfrutar de la comida al aire libre."
                    },
                    new Feature
                    {
                        Name = "Aparcamiento",
                        Description =
                            "El restaurante cuenta con un amplio aparcamiento para la comodidad de los clientes."
                    }
                },
                Reviews =
                {
                }
            });

            //12
            var restaurant = new Restaurant()
            {
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
                Features =
                {
                    new Feature
                    {
                        Name = "Acceso PMR",
                        Description = "Acceso al local adaptado para personas con movilidad reducida."
                    }
                },
                Reviews =
                {
                }
            };

            await context.SaveChangesAsync();
        }
    }
}