using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebApi.Models
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
        
        string StringId { get; }
    }
}
