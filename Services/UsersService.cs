using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class  UsersService: IUsersService
    {
        //Damos a la lista Usuarios el nombre de _usuarios
        private readonly IMongoRepository<UserDetails> _usuarios;
        private readonly IMongoRepository<Addresses> _addresses;
        private readonly IConfiguration _configuration;

        private readonly string key;

        //Conectamos la base de datos con usuarios
        public UsersService(IMongoRepository<UserDetails> usersRepository, IMongoRepository<Addresses> addressesRepository, IConfiguration configuration)
        {
            _usuarios = usersRepository;
            _addresses = addressesRepository;
            _configuration = configuration;
        }

        //Recoge todos los usuarios que estan en la base de datos
        public List<UserDetails> Get() => _usuarios.AsQueryable().ToList();

        //Cogemos el id del users y comparamos el users con el id de users
        public async Task<UserDetails> Get(string id) => await _usuarios.FindByIdAsync(id);

        public UserDetails Login(string email, string password)
        {
            return _usuarios.FilterBy(u => u.Email == email && u.Password == password).FirstOrDefault();
        }

        //Creamos un nuevo users, si ese users no tienen ID se crea un nuevo ID y se inserta en la base de datos
        public async Task<UserDetails> Create(UserDetails user)
        {
            await _usuarios.InsertOneAsync(user);
            return user;
        }

        //Actualizamos la lista de usuarios al insertar nuevo users
        public async Task Update(UserDetails usersIn) => await _usuarios.ReplaceOneAsync(usersIn);

        //Borramos un users de la lista comparando el users con su IP¿
        public async Task Remove(UserDetails usersIn)
        {
            await _addresses.DeleteByIdAsync(usersIn.Address.Id.ToString());
            await _usuarios.DeleteByIdAsync(usersIn.Id.ToString());
            
        }

        public AuthObject? Authenticate(string email, string password)
        {
            try
            {
                var user = this._usuarios.FindOne(x => x.Email == email && x.Password == password);

                if (user == null)
                {
                    return null;
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Surname, user.LastName)
                };
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
                var tokenDescriptor = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials
                );
                var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

                return new AuthObject(token, user);
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

    }
}
