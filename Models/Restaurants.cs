using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WebApi.Repositories;

namespace WebApi.Models
{
    [BsonCollection("Restaurants")]
    public class Restaurants : Document
    {

        public string Name { get; set; } = "";
        public Addresses Address { get; set; }
        public string Descripcion { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Image { get; set; } = "";
        public List<Features> Servicio { get; set; } = new List<Features>();

    }

    public class IBuscaCiudad
    {
        public string Ciudad { get; set; }
    }
}
