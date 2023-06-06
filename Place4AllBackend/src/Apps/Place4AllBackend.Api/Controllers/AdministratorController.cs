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
        [HttpGet("/restaurants")]
        public async Task<ActionResult<ServiceResult<List<RestaurantDto>>>> GetAllRestaurants_admin()
        {
            return Ok(await Mediator.Send(new GetAllRestaurantsQuery()));
        }

        /// <summary>
        /// Get restaurant by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/restaurants/{id:int}")]
        public async Task<ActionResult<ServiceResult<RestaurantDto>>> GetRestaurantById_admin(int id)
        {
            return Ok(await Mediator.Send(new GetRestaurantByIdQuery { RestaurantId = id }));
        }

        /// <summary>
        /// TODO: ¿este controller no sería de tipo Get?
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("features")]
        public async Task<ActionResult<ServiceResult<List<RestaurantDto>>>> GetRestaurantsByFeature_admin(
            GetRestaurantsByFeatureQuery query)
        {
            return Ok(await Mediator.Send(new GetRestaurantsByFeatureQuery()));
        }

        /// <summary>
        /// Get Favorite Restaurants
        /// </summary>
        /// <returns></returns>
        [HttpGet("/users")]
        public async Task<ActionResult<ServiceResult<List<RestaurantDto>>>> GetUserFavoriteRestaurants_admin()
        {
            return Ok(await Mediator.Send(new GetFavoriteRestaurantsQuery()));
        }


        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns></returns>
        [HttpGet("/users")]
        public async Task<ActionResult<ServiceResult<List<ApplicationUserDto>>>> AddFavoriteRestaurant()
        {
            return Ok(await Mediator.Send(new GetAllUsersQuery()));
        }


        /// <summary>
        /// Add favorite restaurant
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("/users")]
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
        [HttpDelete("/restaurants/{id:int}")]
        public async Task<ActionResult<ServiceResult<ApplicationUserDto>>> DeleteFavoriteRestaurant(int id)
        {
            return Ok(await Mediator.Send(new DeleteFavoriteRestaurantCommand { FavoriteRestaurantId = id }));
        }
    }
}