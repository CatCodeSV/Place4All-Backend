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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<RestaurantDto>>>> GetAllRestaurants_admin(
            CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllRestaurantsQuery(), cancellationToken));
        }

        /// <summary>
        /// Get restaurant by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResult<RestaurantDto>>> GetRestaurantById_admin(int id,
            CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetRestaurantByIdQuery { RestaurantId = id }, cancellationToken));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("features")]
        public async Task<ActionResult<ServiceResult<List<RestaurantDto>>>> GetRestaurantsByFeature_admin(
            GetRestaurantsByFeatureQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetRestaurantsByFeatureQuery(), cancellationToken));
        }

        /// <summary>
        /// Get Favorite Restaurants
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("User")]
        public async Task<ActionResult<ServiceResult<List<RestaurantDto>>>> GetUserFavoriteRestaurants_admin(
            CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetFavoriteRestaurantsQuery(), cancellationToken));
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
    }
}