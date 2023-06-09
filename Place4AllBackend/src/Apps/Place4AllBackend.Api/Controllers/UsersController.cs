using MediatR;
using Microsoft.AspNetCore.Mvc;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Application.Restaurants.Commands.Create;
using Place4AllBackend.Application.Restaurants.Queries.GetRestaurantById;
using Place4AllBackend.Application.Restaurants.Queries.GetRestaurants;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Place4AllBackend.Application.ApplicationUser.Commands.Update.AddFavoriteRestaurant;
using Place4AllBackend.Application.ApplicationUser.Commands.Update.RemoveFavoriteRestaurant;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Api.Controllers
{
    /// <summary>
    /// Users
    /// </summary>
    [Authorize]
    public class UsersController : BaseApiController
    {
        /// <summary>
        /// Add favorite restaurant
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ServiceResult<ApplicationUserDto>>> AddFavoriteRestaurant(
            AddFavoriteRestaurantCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Delete favorite restaurant
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResult<ApplicationUserDto>>> DeleteFavoriteRestaurant(int id,
            CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteFavoriteRestaurantCommand { FavoriteRestaurantId = id },
                cancellationToken));
        }
    }
}
