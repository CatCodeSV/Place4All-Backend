using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class  UsersService: IUsersService
    {
        //Damos a la lista Usuarios el nombre de _usuarios
        private readonly IMongoRepository<Users> _usuarios;
        private readonly IMongoRepository<Addresses> _addresses;

        private readonly string key;

        //Conectamos la base de datos con usuarios
        public UsersService(IMongoRepository<Users> usersRepository, IMongoRepository<Addresses> addressesRepository)
        {
            _usuarios = usersRepository;
            _addresses = addressesRepository;
        }

        //Recoge todos los usuarios que estan en la base de datos
        public List<Users> Get() => _usuarios.AsQueryable().ToList();

        //Cogemos el id del users y comparamos el users con el id de users
        public async Task<Users> Get(string id) => await _usuarios.FindByIdAsync(id);

        public Users Login(string email, string password) =>
            _usuarios.FilterBy(u => u.Email == email && u.Password == password).FirstOrDefault();
        //Creamos un nuevo users, si ese users no tienen ID se crea un nuevo ID y se inserta en la base de datos
        public async Task<Users> Create(Users user)
        {
          //  await _addresses.InsertOneAsync(user.Address);
            await _usuarios.InsertOneAsync(user);
            return user;
        }

        //Actualizamos la lista de usuarios al insertar nuevo users
        public async Task Update(Users usersIn) => await _usuarios.ReplaceOneAsync(usersIn);

        //Borramos un users de la lista comparando el users con su IP¿
        public async Task Remove(Users usersIn)
        {
            await _addresses.DeleteByIdAsync(usersIn.Address.Id.ToString());
            await _usuarios.DeleteByIdAsync(usersIn.Id.ToString());
            
        }
    }
}
