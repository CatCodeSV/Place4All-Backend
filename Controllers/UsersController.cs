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
    [Authorize]
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

        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var response = _usersService.Authenticate(email, password);
            if(response == null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }

        [HttpPost]
        [AllowAnonymous]
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

        private Users GetUser(string email, string password) => _usersService.Login(email, password);
    }
}