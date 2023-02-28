using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApi.Models
{
    public class Features : Document
    {

        public string Name { get; set; } = "";
        public string? Description { get; set; }
        

    }
}
