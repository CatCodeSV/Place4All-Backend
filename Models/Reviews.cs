using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WebApi.Repositories;

namespace WebApi.Models;
[BsonCollection("Reviews")]
public class Reviews : Document
{

    public float Value { get; set; }
    public Restaurants Restaurant { get; set; }
    public Users.IUser User { get; set; }
    public Comments? Comment { get; set; }
}
