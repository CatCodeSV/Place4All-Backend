using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Models
{
    [BsonCollection("Users")]
    public class Users : Document
    {

        public string Name { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Gender { get; set; } = "";
        public int Age { get; set; }
        public Addresses Address { get; set; }
        public bool HasDisability { get; set; } = false;
        public decimal? DisabilityDegree { get; set; }
        public string Email { get; set; } = "";
    }
}
[BsonCollection("Users")]
public class UserDetails : Users
{
    public string Password { get; set; } = "";
}

public interface Login
{
    public string email { get; set; }
    public string password { get; set; }
}