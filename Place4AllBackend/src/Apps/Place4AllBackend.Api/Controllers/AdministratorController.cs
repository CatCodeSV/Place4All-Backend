﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Application.Services.ApplicationUser.Queries.GetAllUsers;
using Place4AllBackend.Application.Restaurants.Queries.GetRestaurants;
using Place4AllBackend.Application.Restaurants.Queries.GetRestaurantsByFeatures;
using Place4AllBackend.Application.Restaurants.Queries.GetRestaurantById;
using Place4AllBackend.Application.Restaurants.Queries.GetFavoritesRestaurants;
using Place4AllBackend.Application.ApplicationUser.Commands.Update.AddFavoriteRestaurant;
using Place4AllBackend.Application.ApplicationUser.Commands.Update.RemoveFavoriteRestaurant;
using Place4AllBackend.Application.Services.Restaurants.Commands.Update;
using Place4AllBackend.Application.Services.Restaurants.Commands.Delete;
using Place4AllBackend.Application.Services.ApplicationUser.Queries.GetUserById;
using Place4AllBackend.Application.Services.ApplicationUser.Commands.Update.UpdateUser;
using Place4AllBackend.Application.Services.ApplicationUser.Commands.Delete;
using Place4AllBackend.Application.Services.Restaurants.Queries.GetFullRestaurants;

namespace Place4AllBackend.Api.Controllers
{
    /// <summary>
    /// Administrator
    /// </summary>
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : BaseApiController
    {
        /// <summary>
        /// Get all Restaurants
        /// </summary>
        /// <returns></returns>
        [HttpGet("Restaurants")]
        public async Task<ActionResult<ServiceResult<List<RestaurantDto>>>> GetAllRestaurantsFull()
        {
            return Ok(await Mediator.Send(new GetFullRestaurantsQuery()));
        }


        //TODO: Get Restaurants by name
        //Hacer Query GetRestaurants by name


        /// <summary>
        /// GetRestaurants by Feature
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("Restaurants/Features")]
        public async Task<ActionResult<ServiceResult<List<RestaurantDto>>>> GetRestaurantsByFeatureFull(
            GetRestaurantsByFeatureQuery query)
        {
            return Ok(await Mediator.Send(new GetRestaurantsByFeatureQuery()));
        }

        /// <summary>
        /// Update Restaurant by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("Restaurant/{id:int}")]
        public async Task<ActionResult<ServiceResult<RestaurantDto>>> UpdateRestaurant(int id,
            UpdateRestaurantCommand command)
        {
            command.Id = id;
            return Ok(await Mediator.Send(new UpdateRestaurantCommand
            {
                Id = id,
                Name = command.Name,
                Description = command.Description,
                PhoneNumber = command.PhoneNumber
            }));
        }

        /// <summary>
        /// Delete Restaurant by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Restaurant/{id:int}")]
        public async Task<ActionResult<ServiceResult<RestaurantDto>>> DeleteRestaurant(int id)
        {
            return Ok(await Mediator.Send(new DeleteRestaurantCommand() { Id = id }));
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns></returns>
        [HttpGet("Users")]
        public async Task<ActionResult<ServiceResult<List<ApplicationUserDto>>>> GetAllUsers()
        {
            return Ok(await Mediator.Send(new GetAllUsersQuery()));
        }

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("User/{id}")]
        public async Task<ActionResult<ServiceResult<ApplicationUserDto>>> GetUserById(string id)
        {
            return Ok(await Mediator.Send(new GetUserByIdQuery() { UserId = id }));
        }

        /// <summary>
        /// Update User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("User/{id}")]
        public async Task<ActionResult<ServiceResult<ApplicationUserDto>>> UpdateUser(string id,
            UpdateUserCommand command)
        {
            command.Id = id;
            return Ok(await Mediator.Send(new UpdateUserCommand
            {
                Id = id,
                Name = command.Name,
                LastName = command.LastName,
                Gender = command.Gender,
                BirthDate = command.BirthDate,
                HasDisability = command.HasDisability,
                DisabilityType = command.DisabilityType,
                DisabilityDegree = command.DisabilityDegree,
                UserName = command.UserName
            }));
        }

        /// <summary>
        /// Get Favorite Restaurants
        /// </summary>
        /// <returns></returns>
        [HttpGet("Restaurants/Users")]
        public async Task<ActionResult<ServiceResult<List<RestaurantDto>>>> GetUserFavoriteRestaurants()
        {
            return Ok(await Mediator.Send(new GetFavoriteRestaurantsQuery()));
        }

        /// <summary>
        /// Add favorite restaurant
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("Users/Restaurants")]
        public async Task<ActionResult<ServiceResult<ApplicationUserDto>>> AddFavoriteRestaurant(
            AddFavoriteRestaurantCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Delete favorite restaurant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Users/Restaurants/{id:int}")]
        public async Task<ActionResult<ServiceResult<ApplicationUserDto>>> DeleteFavoriteRestaurant(int id)
        {
            return Ok(await Mediator.Send(new DeleteFavoriteRestaurantCommand { FavoriteRestaurantId = id }));
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("User/{id}")]
        public async Task<ActionResult<ServiceResult<ApplicationUserDto>>> DeleteUser(string id)
        {
            return Ok(await Mediator.Send(new DeleteUserCommand() { Id = id }));
        }
    }
}