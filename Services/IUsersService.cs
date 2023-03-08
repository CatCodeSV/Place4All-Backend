using MongoDB.Bson;
using WebApi.Models;

namespace WebApi.Services;

public interface IUsersService
{
    List<UserDetails> Get();

    //Cogemos el id del users y comparamos el users con el id de users
    Task<UserDetails> Get(string id);

    UserDetails Login(string email, string password);
    //Creamos un nuevo users, si ese users no tienen ID se crea un nuevo ID y se inserta en la base de datos
    Task<UserDetails> Create(UserDetails users);

    //Actualizamos la lista de usuarios al insertar nuevo users
    Task Update(UserDetails usersIn);

    //Borramos un users de la lista comparando el users con su IP¿
    Task Remove(UserDetails usersIn);

    //Creamos el objeto Authenticate para generar el token
    AuthObject? Authenticate(string email, string password);
}