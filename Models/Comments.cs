using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApi.Models;

public class Comments
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Title { get; set; }
    public int? InformationAccuracy { get; set; }
    public List<Features> HasFeatures { get; set; }
}