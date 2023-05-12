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
                context.Features.Add(new Feature()
                {
                    Name = "Acceso PMR",
                    Description = "Acceso al local adaptado para personas con movilidad reducida",
                });
                context.Features.Add(new Feature()
                {
                    Name = "Perro guía",
                    Description = "Se permite la entrada de perros guía para acompañar a personas con discapacidad",
                });
                context.Features.Add(new Feature()
                {
                    Name = "Mesas adaptadas",
                    Description = "El restaurante cuenta con mesas adaptadas para personas con discapacidad, como mesas a diferentes alturas o con espacio suficiente para sillas de ruedas.",
                });
                context.Features.Add(new Feature()
                {
                    Name = "Baño adaptado",
                    Description = "El baño del restaurante está adaptado para personas con discapacidad y cuenta con barras de apoyo, inodoro elevado y lavabo accesible.",
                });
                context.Features.Add(new Feature()
                {
                    Name = "Menú Vegetariano",
                    Description = "Se ofrecen opciones vegetarianas en la carta",
                });
                context.Features.Add(new Feature()
                {
                    Name = "Menú Vegano",
                    Description = "Se ofrecen opciones veganas en la carta",
                });
                context.Features.Add(new Feature()
                {
                    Name = "Menú Sin Lactosa",
                    Description = "Todos los platos con lácteos y derivados se realizan con leche sin lactosa",
                });
                context.Features.Add(new Feature()
                {
                    Name = "Menú Sin Gluten",
                    Description = "Se ofrece una amplia variedad de platos sin gluten para las personas con intolerancia o alergia al gluten.",
                });
                context.Features.Add(new Feature()
                {
                    Name = "Menú Alérgenos",
                    Description = "El restaurante cuenta con un menú con información de los posibles alérgenos",
                });
                context.Features.Add(new Feature()
                {
                    Name = "Terraza",
                    Description = "El restaurante cuenta con una terraza al aire libre.",
                });
                context.Features.Add(new Feature()
                {
                    Name = "Aparcamiento",
                    Description = "El restaurante cuenta con un amplio aparcamiento para la comodidad de los clientes.",
                });
                context.Features.Add(new Feature()
                {
                    Name = "Carta Braile",
                    Description = "Se dispone de una carta en braile y de un código QR para disponer de la carta online con lectura automática",
                });
                context.Features.Add(new Feature()
                {
                    Name = "Intérprete Signos",
                    Description = "El personal del local sabe interpretar y comunicarse mediante el lenguaje de signos",
                });
                context.Features.Add(new Feature()
                {
                    Name = "Aparcacoches",
                    Description = "El restaurante cuenta con servicio de aparcacoches para la comodidad de los clientes.",
                });


                await context.SaveChangesAsync();
            }
        }
    }
}
