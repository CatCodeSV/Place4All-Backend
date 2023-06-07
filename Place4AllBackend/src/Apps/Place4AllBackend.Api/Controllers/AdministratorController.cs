using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Application.Services.ApplicationUser.Queries.GetAllUsers;
using Microsoft.AspNetCore.Mvc;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Application.Restaurants.Queries.GetRestaurants;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Place4AllBackend.Application.Restaurants.Queries.GetRestaurantsByFeatures;
using Place4AllBackend.Application.Restaurants.Queries.GetRestaurantById;
using Place4AllBackend.Application.Restaurants.Queries.GetFavoritesRestaurants;
using Place4AllBackend.Application.ApplicationUser.Commands.Update.AddFavoriteRestaurant;
using Place4AllBackend.Application.ApplicationUser.Commands.Update.RemoveFavoriteRestaurant;
using Place4AllBackend.Application.Services.Restaurants.Commands.Update;
using Microsoft.CodeAnalysis.CSharp;

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
        public async Task<ActionResult<ServiceResult<List<RestaurantSummarizedDto>>>> GetAllRestaurants()
        {
            return Ok(await Mediator.Send(new GetAllRestaurantsQuery()));
        }

        /// <summary>
        /// Get restaurant by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Restaurant/{id:int}")]
        public async Task<ActionResult<ServiceResult<RestaurantSummarizedDto>>> GetRestaurantById(int id)
        {
            return Ok(await Mediator.Send(new GetRestaurantByIdQuery { RestaurantId = id }));
        }


        //TODO: Get Restaurants by name
        //Hacer Query GetRestaurants by name


        /// <summary>
        /// GetRestaurants by Feature
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("Restaurants/Features")]
        public async Task<ActionResult<ServiceResult<List<RestaurantSummarizedDto>>>> GetRestaurantsByFeature(
            GetRestaurantsByFeatureQuery query)
        {
            return Ok(await Mediator.Send(new GetRestaurantsByFeatureQuery()));
        }


        [HttpPut("Restaurant/{id:int}")]
        public async Task<ActionResult<ServiceResult<RestaurantDto>>> UpdateRestaurant(int id, UpdateRestaurantCommand command)
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
        /// Get all Users
        /// </summary>
        /// <returns></returns>
        [HttpGet("Users")]
        public async Task<ActionResult<ServiceResult<List<ApplicationUserDto>>>> GetAllUsers()
        {
            return Ok(await Mediator.Send(new GetAllUsersQuery()));
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
    }
}