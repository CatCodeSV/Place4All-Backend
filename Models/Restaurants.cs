using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApi.Models
{
    public class Restaurants
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
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
