using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using WebApi.Repositories;

namespace WebApi.Models
{
    [BsonCollection("Users")]
    public class Users :Document
    {

        public string Name { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Gender { get; set; } = "";
        public int Age { get; set; }
        public Addresses Address { get; set; }
        public bool HasDisability { get; set; } = false;
        public decimal? DisabilityDegree { get; set; }
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";

        public interface IUser
        {
            public string Name { get; set; }
            public string LastName { get; set; }

            //public string Gender { get; set; }
            //public int Age { get; set; } 
            //Creo que al devolver un usuario su genero y su edad es irrelevante

            public Addresses Address { get; set; }
            public bool HasDisability { get; set; }
            public decimal? DisabilityDegree { get; set; }
            string Email { get; set; }
            object Id { get; }
        }
    }

    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
