using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WebApi.Repositories;

namespace WebApi.Models
{
    [BsonCollection("Addresses")]
    public class Addresses : Document
    {
        public string Street { get; set; } = "";
        public int Number { get; set; }
        public string City { get; set; } = "";
        public string ZipCode { get; set; } = "";
        public string Province { get; set; } = "";
    }
}
