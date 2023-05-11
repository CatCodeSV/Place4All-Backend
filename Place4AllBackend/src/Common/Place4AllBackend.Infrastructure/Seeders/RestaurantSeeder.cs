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
                        InformationAccuracy = InformationAccuracy.VeryGood,
                        RestaurantId = 1
                    },
                    new Review()
                    {
                        Comment = "Estuvo muy bien, me hubiera gustado que tuviera más opciones vegetarianas",
                        Value = 3,
                        Creator = userLaura?.Id,
                        InformationAccuracy = InformationAccuracy.Good,
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
                    new Review()
                    {
                        Comment = "El sushi es excelente y el servicio es muy amable.",
                        Value = 5,
                        Creator = userAlex?.Id,
                        InformationAccuracy = InformationAccuracy.VeryGood,
                        RestaurantId = 2
                    },
                    new Review()
                    {
                        Comment = "Un sitio estupendo para comer sushi. Los precios son razonables y el ambiente es agradable.",
                        Value = 4,
                        Creator = userLaura?.Id,
                        InformationAccuracy = InformationAccuracy.VeryGood,
                        RestaurantId = 2
                    },
                    new Review()
                    {
                        Comment = "La calidad del sushi es muy buena, pero el servicio puede ser un poco lento en horas punta y el helado no es de leche sin lactosa.",
                        Value = 2,
                        Creator = userSandra?.Id,
                        InformationAccuracy = InformationAccuracy.Bad,
                        RestaurantId = 2
                    }
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
                    new Review()
                    {
                        Comment = "Un auténtico bistró parisino en Madrid, la comida es espectacular y el ambiente es acogedor. Definitivamente volveré.",
                        Value = 5,
                        Creator = userSandra?.Id,
                        InformationAccuracy = InformationAccuracy.VeryGood,
                        RestaurantId = 3
                    },
                    new Review()
                    {
                        Comment = "Buena comida y ambiente pero el servicio podría mejorar un poco y no cuenta con rampa de acceso para acceder en silla de ruedas.",
                        Value = 3,
                        Creator = userAlex?.Id,
                        InformationAccuracy = InformationAccuracy.Good,
                        RestaurantId = 3
                    },
                    new Review()
                    {
                        Comment = "Los platos son muy bien presentados y tienen un sabor delicioso. Recomendado.",
                        Value = 4,
                        Creator = userLaura?.Id,
                        InformationAccuracy = InformationAccuracy.VeryGood,
                        RestaurantId = 3
                    }
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
                    new Review()
                    {
                        Comment = "Me encantó la pasta y el tiramisú, además tienen opciones sin gluten, definitivamente volveré",
                        Value = 4,
                        Creator = userLaura?.Id,
                        InformationAccuracy = InformationAccuracy.Good,
                        RestaurantId = 4
                    },
                    new Review()
                    {
                        Comment = "La comida estaba buena pero el servicio fue un poco lento y no tenían el menú online para poder escucharlo",
                        Value = 3,
                        Creator = userAlex?.Id,
                        InformationAccuracy = InformationAccuracy.Good,
                        RestaurantId = 4
                    },
                    new Review()
                    {
                        Comment = "Muy buen ambiente, platos muy sabrosos y fácilmente accesible en coche, lo recomiendo",
                        Value = 5,
                        Creator = userSandra?.Id,
                        InformationAccuracy = InformationAccuracy.VeryGood,
                        RestaurantId = 4
                    }
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
                        Description = "El personal del bar sabe interpretar y comunicarse mediante el lenguaje de signos"
                    },
                    new Feature
                    {
                        Name = "Perro guía",
                        Description =
                            "Se permite la entrada de perros guía para acompañar a personas con discapacidad visual."
                    },
                    new Feature
                    {
                        Name = "Menú del día",
                        Description =
                            "Menú del día con platos variados y económicos."
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
                    new Review()
                    {
                        Comment = "Muy buena selección de tapas de pescado y marisco, todo fresquísimo. Recomendado!",
                        Value = 4,
                        Creator = userLaura?.Id,
                        InformationAccuracy = InformationAccuracy.VeryGood,
                        RestaurantId = 5
                    },
                    new Review()
                    {
                        Comment = "El ambiente es agradable y las tapas están bien, aunque me parecieron un poco caras.",
                        Value = 3,
                        Creator = userAlex?.Id,
                        InformationAccuracy = InformationAccuracy.VeryGood,
                        RestaurantId = 5
                    },
                    new Review()
                    {
                        Comment = "Buena atención y ambiente, pero es demasiado pequeño, no es cómodo si vas en silla de ruedas",
                        Value = 3,
                        Creator = userSandra?.Id,
                        InformationAccuracy = InformationAccuracy.Good,
                        RestaurantId = 5
                    }
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
                    new Review()
                    {
                        Comment = "La carne estaba increíble, el mejor asado que he probado en Zaragoza, volveré sin duda",
                        Value = 5,
                        Creator = userAlex?.Id,
                        InformationAccuracy = InformationAccuracy.Good,
                        RestaurantId = 6
                    },
                    new Review()
                    {
                        Comment = "El ambiente es muy acogedor y la atención es buena, aunque me pareció un poco caro para lo que ofrecen",
                        Value = 3,
                        Creator = userLaura?.Id,
                        InformationAccuracy = InformationAccuracy.Good,
                        RestaurantId = 6
                    },
                    new Review()
                    {
                        Comment = "La comida estaba deliciosa, el restaurante es muy amplio puedo moverme con total comodidad y la atención fue excelente, definitivamente recomiendo este lugar",
                        Value = 4,
                        Creator = userSandra?.Id,
                        InformationAccuracy = InformationAccuracy.VeryGood,
                        RestaurantId = 6
                    }
                }
            });



            await context.SaveChangesAsync();
        }
    }
}