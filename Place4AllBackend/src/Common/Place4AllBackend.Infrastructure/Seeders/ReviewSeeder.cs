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
                Value = 3,
                Creator = context.Users.FirstOrDefault(x => x.Email == "keevinaguirre@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.VeryGood,
                RestaurantId = 1
            });
            context.Reviews.Add(new Review()
            {
                Comment = "Estuvo muy bien, pero me hubiera gustado que tuviera más opciones vegetarianas",
                Value = 3,
                Creator = context.Users.FirstOrDefault(x => x.Email == "lauragilf.13@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.Good,
                RestaurantId = 1
            });
            context.Reviews.Add(new Review()
            {
                Comment = "Repetiré seguro, me encantó la comida y el servicio",
                Value = 3,
                Creator = context.Users.FirstOrDefault(x => x.Email == "diazmalo@hotmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.VeryGood,
                RestaurantId = 1
            });

            context.Reviews.Add(new Review()
            {
                Comment = "El sushi es excelente y el servicio es muy amable.",
                Value = 3,
                Creator = context.Users.FirstOrDefault(x => x.Email == "keevinaguirre@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.VeryGood,
                RestaurantId = 2
            });
            context.Reviews.Add(new Review()
            {
                Comment = "Un sitio estupendo para comer sushi. Los precios son razonables y el ambiente es agradable.",
                Value = 4,
                Creator = context.Users.FirstOrDefault(x => x.Email == "lauragilf.13@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.VeryGood,
                RestaurantId = 2
            });
            context.Reviews.Add(new Review()
            {
                Comment = "La calidad del sushi es muy buena, pero el servicio puede ser un poco lento en horas punta y el helado no es de leche sin lactosa.",
                Value = 3,
                Creator = context.Users.FirstOrDefault(x => x.Email == "diazmalo@hotmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.Bad,
                RestaurantId = 2
            });

            context.Reviews.Add(new Review()
            {
                Comment = "Buena comida y ambiente pero el servicio podría mejorar un poco y no cuenta con rampa de acceso para acceder en silla de ruedas",
                Value = 2,
                Creator = context.Users.FirstOrDefault(x => x.Email == "lauragilf.13@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.Good,
                RestaurantId = 3
            });
            context.Reviews.Add(new Review()
            {
                Comment = "Los platos son muy bien presentados y tienen un sabor delicioso. Recomendado.",
                Value = 4,
                Creator = context.Users.FirstOrDefault(x => x.Email == "diazmalo@hotmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.VeryGood,
                RestaurantId = 3
            });

            context.Reviews.Add(new Review()
            {
                Comment = "Muy buen ambiente, platos muy sabrosos y fácilmente accesible en coche, lo recomiendo",
                Value = 3,
                Creator = context.Users.FirstOrDefault(x => x.Email == "keevinaguirre@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.VeryGood,
                RestaurantId = 4
            });
            context.Reviews.Add(new Review()
            {
                Comment = "Me encantó la pasta y el tiramisú, además tienen muchas opciones sin gluten, definitivamente volveré.",
                Value = 5,
                Creator = context.Users.FirstOrDefault(x => x.Email == "lauragilf.13@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.VeryGood,
                RestaurantId = 4
            });
            context.Reviews.Add(new Review()
            {
                Comment = "La comida estaba buena pero el servicio fue un poco lento y no tenían el menú online para poder escucharlo",
                Value = 3,
                Creator = context.Users.FirstOrDefault(x => x.Email == "diazmalo@hotmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.Good,
                RestaurantId = 4
            });

            context.Reviews.Add(new Review()
            {
                Comment = "Muy buena selección de tapas de pescado y marisco, todo fresquísimo. Recomendado!",
                Value = 5,
                Creator = context.Users.FirstOrDefault(x => x.Email == "lauragilf.13@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.VeryGood,
                RestaurantId = 5
            });
            context.Reviews.Add(new Review()
            {
                Comment = "Buena atención y ambiente, pero es demasiado pequeño, no es cómodo si vas en silla de ruedas",
                Value = 3,
                Creator = context.Users.FirstOrDefault(x => x.Email == "diazmalo@hotmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.Good,
                RestaurantId = 5
            });

            context.Reviews.Add(new Review()
            {
                Comment = "El ambiente es muy acogedor y la atención es buena, aunque me pareció un poco caro para lo que ofrecen",
                Value = 3,
                Creator = context.Users.FirstOrDefault(x => x.Email == "keevinaguirre@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.VeryGood,
                RestaurantId = 6
            });
            context.Reviews.Add(new Review()
            {
                Comment = "La comida estaba deliciosa, el restaurante es muy amplio puedo moverme con total comodidad y la atención fue excelente, definitivamente recomiendo este lugar",
                Value = 5,
                Creator = context.Users.FirstOrDefault(x => x.Email == "diazmalo@hotmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.Good,
                RestaurantId = 6
            });

            context.Reviews.Add(new Review()
            {
                Comment = "La pizza estaba deliciosa y el precio era muy asequible, sin duda volveré",
                Value = 4,
                Creator = context.Users.FirstOrDefault(x => x.Email == "lauragilf.13@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.VeryGood,
                RestaurantId = 7
            });
            context.Reviews.Add(new Review()
            {
                Comment = "La pasta estaba un poco salada para mi gusto, y tengo hipertensión",
                Value = 2,
                Creator = context.Users.FirstOrDefault(x => x.Email == "keevinaguirre@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.Good,
                RestaurantId = 7
            });

            context.Reviews.Add(new Review()
            {
                Comment = "Excelente combinación de sabores y presentación, también es un local amplio y tranquilo, puedo conversar tranquilamente sin problemas para escuchar. Sin duda volveré a visitar este lugar.",
                Value = 5,
                Creator = context.Users.FirstOrDefault(x => x.Email == "lauragilf.13@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.VeryGood,
                RestaurantId = 8
            });
            context.Reviews.Add(new Review()
            {
                Comment = "El servicio fue impecable, pero algunos de los platos eran un poco demasiado creativos para mi gusto y no sabía bien qué llevaban. Por otro lado, el servicio aparcacoches me encantó, te traen el coche a puerta para acceder más fácilmente, sin tener que recorrer grandes distancias.",
                Value = 4,
                Creator = context.Users.FirstOrDefault(x => x.Email == "keevinaguirre@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.Good,
                RestaurantId = 8
            });

            context.Reviews.Add(new Review()
            {
                Comment = "La comida estaba buena, pero hay un pequeño escalón en la entrada. Aún así, lo recomiendo porque está todo muy rico.",
                Value = 2,
                Creator = context.Users.FirstOrDefault(x => x.Email == "lauragilf.13@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.VeryBad,
                RestaurantId = 9
            });
            context.Reviews.Add(new Review()
            {
                Comment = "Los tacos de carnitas estaban espectaculares y además los hacen también sin gluten. Definitivamente volveré",
                Value = 5,
                Creator = context.Users.FirstOrDefault(x => x.Email == "keevinaguirre@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.VeryGood,
                RestaurantId = 9
            });

            context.Reviews.Add(new Review()
            {
                Comment = "Me encantó la comida y la música en vivo.",
                Value = 5,
                Creator = context.Users.FirstOrDefault(x => x.Email == "keevinaguirre@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.VeryGood,
                RestaurantId = 10
            });
            context.Reviews.Add(new Review()
            {
                Comment = "Las tapas estaban bastante bien, pero la terraza es muy pequeña y la música un poco alta para mi gusto",
                Value = 3,
                Creator = context.Users.FirstOrDefault(x => x.Email == "lauragilf.13@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.Good,
                RestaurantId = 10
            });
            context.Reviews.Add(new Review()
            {
                Comment = "Muy buen lugar para probar tapas andaluzas y disfrutar del ambiente.",
                Value = 4,
                Creator = context.Users.FirstOrDefault(x => x.Email == "diazmalo@hotmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.VeryGood,
                RestaurantId = 10
            });

            context.Reviews.Add(new Review()
            {
                Comment = "Gran experiencia en familia, disfrutamos mucho de la comida y el servicio",
                Value = 4,
                Creator = context.Users.FirstOrDefault(x => x.Email == "lauragilf.13@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.Good,
                RestaurantId = 11
            });

            context.Reviews.Add(new Review()
            {
                Comment = "Excelente trato y comida casera muy rica, lo recomiendo sin duda alguna.",
                Value = 4,
                Creator = context.Users.FirstOrDefault(x => x.Email == "keevinaguirre@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.VeryGood,
                RestaurantId = 12
            });
            context.Reviews.Add(new Review()
            {
                Comment = "Buena relación calidad-precio, pero el local estaba un poco lleno y se hacía un poco de ruido.",
                Value = 3,
                Creator = context.Users.FirstOrDefault(x => x.Email == "lauragilf.13@gmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.Good,
                RestaurantId = 12
            });
            context.Reviews.Add(new Review()
            {
                Comment = "Un sitio genial para ir con toda la familia, los platos estaban riquísimos y el servicio fue excelente",
                Value = 4,
                Creator = context.Users.FirstOrDefault(x => x.Email == "diazmalo@hotmail.com")?.Id,
                InformationAccuracy = InformationAccuracy.VeryGood,
                RestaurantId = 12
            });

            await context.SaveChangesAsync();
        }
    }
}