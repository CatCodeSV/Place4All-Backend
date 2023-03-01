using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApi.Models;

namespace WebApi.Services
{
    public class  UsersService
    {
        //Damos a la lista Usuarios el nombre de _usuarios
        private readonly IMongoCollection<Users> _usuarios;

        private readonly string key;

        //Conectamos la base de datos con usuarios
        public UsersService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _usuarios = database.GetCollection<Users>("Users");
        }

        //Recoge todos los usuarios que estan en la base de datos
        public async Task<List<Users>> Get() => await _usuarios.Find(usuario => true).ToListAsync();

        //Cogemos el id del users y comparamos el users con el id de users
        public async Task<Users> Get(string id) => await _usuarios.Find(usuario => usuario.Id == id).FirstOrDefaultAsync();

        public async Task<Users> Login(string email, string password) =>
             await _usuarios.Find(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
        //Creamos un nuevo users, si ese users no tienen ID se crea un nuevo ID y se inserta en la base de datos
        public async Task<Users> Create(Users users)
        {
            users.Id ??= new BsonObjectId(ObjectId.GenerateNewId()).ToString();
            await _usuarios.InsertOneAsync(users);
            return users;
        }

        //Actualizamos la lista de usuarios al insertar nuevo users
        public async Task Update(string id, Users usersIn) => await _usuarios.ReplaceOneAsync(Builders<Users>.Filter.Eq(s => s.Id, id), usersIn);

        //Borramos un users de la lista comparando el users con su IP¿
        public async Task Remove(Users usersIn) => await _usuarios.DeleteOneAsync(usuario => usuario.Id == usersIn.Id);

        //Método Authenticate . Este método tomará el correo electrónico y la contraseña pasados ​​desde el formulario de inicio de sesión o, en nuestro caso, el cuerpo de la solicitud, y verificará si las credenciales son válidas y, de ser así, creará el token con los datos que queremos dentro
        public async Task <string> Authenticate (string email, string password)
        {
            var user = this._usuarios.Find(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey),
                        SecurityAlgorithms.HmacSha256Signature
                    )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
