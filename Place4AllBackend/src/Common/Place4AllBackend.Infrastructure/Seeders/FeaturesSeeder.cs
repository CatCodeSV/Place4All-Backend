using Place4AllBackend.Domain.Entities;
using Place4AllBackend.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Place4AllBackend.Infrastructure.Seeders
{
public class FeaturesSeeder
{
        public static async Task SeedSampleFeatures(ApplicationDbContext context)
        {
            if (!context.Features.Any())
            {
                //1
                context.Features.Add(new Feature()
                {
                    Id = 1,
                    Name = "Acceso PMR",
                    Description = "Acceso al local adaptado para personas con movilidad reducida",
                });
                //2
                context.Features.Add(new Feature()
                {
                    Id = 2,
                    Name = "Perro Asistencia",
                    Description = "Se permite la entrada de perros de asistencia",
                });
                //3
                context.Features.Add(new Feature()
                {
                    Id = 3,
                    Name = "Mesas adaptadas",
                    Description = "El restaurante cuenta con mesas adaptadas para personas con discapacidad, como mesas a diferentes alturas o con espacio suficiente para sillas de ruedas.",
                });
                //4
                context.Features.Add(new Feature()
                {
                    Id = 4,
                    Name = "Baño adaptado",
                    Description = "El baño del restaurante está adaptado para personas con discapacidad y cuenta con barras de apoyo, inodoro elevado y lavabo accesible.",
                });
                //5
                context.Features.Add(new Feature()
                {
                    Id = 5,
                    Name = "Menú Vegetariano",
                    Description = "Se ofrecen opciones vegetarianas en la carta",
                });
                //6
                context.Features.Add(new Feature()
                {
                    Id = 6,
                    Name = "Menú Vegano",
                    Description = "Se ofrecen opciones veganas en la carta",
                });
                //7
                context.Features.Add(new Feature()
                {
                    Id = 7,
                    Name = "Menú Sin Lactosa",
                    Description = "Todos los platos con lácteos y derivados se realizan con leche sin lactosa",
                });
                //8
                context.Features.Add(new Feature()
                {
                    Id = 8,
                    Name = "Menú Sin Gluten",
                    Description = "Se ofrece una amplia variedad de platos sin gluten para las personas con intolerancia o alergia al gluten.",
                });
                //9
                context.Features.Add(new Feature()
                {
                    Id = 9,
                    Name = "Menú Alérgenos",
                    Description = "El restaurante cuenta con un menú con información de los posibles alérgenos",
                });
                //10
                context.Features.Add(new Feature()
                {
                    Id = 10,
                    Name = "Terraza",
                    Description = "El restaurante cuenta con una terraza al aire libre.",
                });
                //11
                context.Features.Add(new Feature()
                {
                    Id = 11,
                    Name = "Aparcamiento",
                    Description = "El restaurante cuenta con un amplio aparcamiento para la comodidad de los clientes.",
                });
                //12
                context.Features.Add(new Feature()
                {
                    Id = 12,
                    Name = "Carta Braile",
                    Description = "Se dispone de una carta en braile y de un código QR para disponer de la carta online con lectura automática",
                });
                //13
                context.Features.Add(new Feature()
                {
                    Id = 13,
                    Name = "Intérprete Signos",
                    Description = "El personal del local sabe interpretar y comunicarse mediante el lenguaje de signos",
                });
                //14
                context.Features.Add(new Feature()
                {
                    Id = 14,
                    Name = "Aparcacoches",
                    Description = "El restaurante cuenta con servicio de aparcacoches para la comodidad de los clientes.",
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
