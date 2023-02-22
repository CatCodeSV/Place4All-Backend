using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApi.Models;

public class Reviews
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public float Value { get; set; }
    public Restaurants Restaurant { get; set; }
    public Users User { get; set; }
    public Comments? Comment { get; set; }
}
