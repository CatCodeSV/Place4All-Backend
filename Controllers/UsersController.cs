﻿using System;
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
    [Route("UsersUsers")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;
        private readonly AddressesService _addressesService;
        private readonly IConfiguration _configuration;

        public UsersController(UsersService usersService, AddressesService addressesService, IConfiguration config)
        {
            _usersService = usersService;
            _addressesService = addressesService;
            _configuration = config;
        }
        
        [HttpGet]
        public ActionResult<List<Users>> Get() => _usersService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Users> Get(string id) => _usersService.Get(id);

        [HttpPost]
        public ActionResult<Users> Create(Users users)
        {
            var usuarioD = HasDireccion(users);
            var usuarioCreada = _usersService.Create(usuarioD);

            return CreatedAtRoute("", new { id = users.Id }, usuarioCreada);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, Users usersInf)
        {
            var usuario = _usersService.Get(id);

            if (usuario == null)
            {
                return NotFound();
            }

            usersInf.Id = usuario.Id;
            _usersService.Update(id, usersInf);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var usuario = _usersService.Get(id);


            if (usuario == null)
            {
                return NotFound();
            }
            DeleteDireccion(usuario);
            _usersService.Remove(usuario);

            return NoContent();
        }
        private Users HasDireccion(Users users)
        {
            
            if (users.Address.Id == null)
            {
                var direccionD = _addressesService.Create(users.Address);
                users.Address = direccionD;
                return users;
            }

            var direccion = _addressesService.Get(users.Address.Id);
            if (direccion == null)
            {
                direccion = _addressesService.Create(users.Address);
                users.Address = direccion;
                return users;
            }

            return users;
        }

        private void DeleteDireccion(Users users)
        {
            _addressesService.Remove(users.Address);
        }
        
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Post(Login login)
        {
            if (login.Email != null && login.Password != null)
            {
                var user = await GetUser(login.Email, login.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.Id),
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

        private async Task<Users> GetUser(string email, string password) => _usersService.Login(email, password);
    }
}

public class LoginResponse
{
    public string Token { get; set; }
    public Users Users { get; set; }
}