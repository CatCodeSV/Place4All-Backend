using MongoDB.Bson;
using WebApi.Models;

namespace WebApi.Services;

public interface IUsersService
{
    List<Users> Get();

    //Cogemos el id del users y comparamos el users con el id de users
    Task<Users> Get(string id);

    Users Login(string email, string password);
    //Creamos un nuevo users, si ese users no tienen ID se crea un nuevo ID y se inserta en la base de datos
    Task<Users> Create(Users users);

    //Actualizamos la lista de usuarios al insertar nuevo users
    Task Update(Users usersIn);

    //Borramos un users de la lista comparando el users con su IP¿
    Task Remove(Users usersIn);
    object Authenticate(string email, string password);
}