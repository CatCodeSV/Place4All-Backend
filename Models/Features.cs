using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WebApi.Repositories;

namespace WebApi.Models
{
    [BsonCollection("Features")]
    public class Features : Document
    {

        public string Name { get; set; } = "";
        public string? Description { get; set; }
        

    }
}
