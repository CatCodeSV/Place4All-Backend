using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IAddressesService _addressesService;
        private readonly IConfiguration _configuration;

        public UsersController(IUsersService usersService, IAddressesService addressesService, IConfiguration config)
        {
            _usersService = usersService;
            _addressesService = addressesService;
            _configuration = config;
        }

        [HttpGet]
        public ActionResult<List<Users>> Get() => _usersService.Get();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Users>> Get(string id) => await _usersService.Get(id);

        [HttpPost]
        public async Task<ActionResult<Users>> Create(Users users)
        {
            var usuarioD = await HasDireccion(users);
            var usuarioCreada = await _usersService.Create(usuarioD);

            return CreatedAtRoute("", new { id = users.Id }, usuarioCreada);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, Users usersInf)
        {
            var usuario =await _usersService.Get(id);

            if (usuario == null)
            {
                return NotFound();
            }

            usersInf.Id = usuario.Id;
           await _usersService.Update(usersInf);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var usuario = await _usersService.Get(id);


            if (usuario == null)
            {
                return NotFound();
            }
            DeleteDireccion(usuario);
           await _usersService.Remove(usuario);

            return NoContent();
        }
        private async Task<Users> HasDireccion(Users users)
        {
            
            if (users.Address.Id == null)
            {
                var direccionD = await _addressesService.Create(users.Address);
                users.Address = direccionD;
                return users;
            }

            var direccion = await _addressesService.Get(users.Address.Id.ToString());
            if (direccion == null)
            {
                direccion = await _addressesService.Create(users.Address);
                users.Address = direccion;
                return users;
            }

            return users;
        }

        private async void DeleteDireccion(Users users)
        {
            _addressesService.Remove(users.Address);
        }
        
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Post(Login login)
        {
            if (login.Email != null && login.Password != null)
            {
                var user = GetUser(login.Email, login.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("DisplayName", $"{user.Name} {user.LastName}"),
                        new Claim("Email", user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    var response = new LoginResponse
                    {
                        Token= new JwtSecurityTokenHandler().WriteToken(token),
                        Users = user
                    };
                    return Ok(response);
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return Unauthorized();
            }
        }

        private Users GetUser(string email, string password) => _usersService.Login(email, password);
    }
}

public class LoginResponse
{
    public string Token { get; set; }
    public Users Users { get; set; }
}