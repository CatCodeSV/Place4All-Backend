using MongoDB.Bson;
using MongoDB.Driver;
using WebApi.Models;

namespace WebApi.Services
{
    public class UsersService
    {
        //Damos a la lista Usuarios el nombre de _usuarios
        private readonly IMongoCollection<Users> _usuarios;
        private readonly AddressesService _addressesService;

        //Conectamos la base de datos con usuarios
        public UsersService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _usuarios = database.GetCollection<Users>("Users");
        }

        //Recoge todos los usuarios que estan en la base de datos
        public List<Users> Get() => _usuarios.Find(usuario => true).ToList();

        //Cogemos el id del users y comparamos el users con el id de users
        public Users Get(string id) => _usuarios.Find<Users>(usuario => usuario.Id == id).FirstOrDefault();

        public Users Login(string email, string password) =>
            _usuarios.Find<Users>(u => u.Email == email && u.Password == password).FirstOrDefault();
        //Creamos un nuevo users, si ese users no tienen ID se crea un nuevo ID y se inserta en la base de datos
        public Users Create(Users users)
        {
            users.Id ??= new BsonObjectId(ObjectId.GenerateNewId()).ToString();
            _usuarios.InsertOne(users);
            return users;
        }

        //Actualizamos la lista de usuarios al insertar nuevo users
        public void Update(string id, Users usersIn) => _usuarios.ReplaceOne(Builders<Users>.Filter.Eq(s => s.Id, id), usersIn);

        //Borramos un users de la lista comparando el users con su IP¿
        public void Remove(Users usersIn) => _usuarios.DeleteOne(usuario => usuario.Id == usersIn.Id);
    }
}
