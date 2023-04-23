using MediatR;
using Microsoft.AspNetCore.Mvc;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Application.Restaurants.Commands.Create;
using Place4AllBackend.Application.Restaurants.Queries.GetRestaurantById;
using Place4AllBackend.Application.Restaurants.Queries.GetRestaurants;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using Place4AllBackend.Application.ApplicationUser.Commands.Create;
using Place4AllBackend.Application.ApplicationUser.Commands.Update;

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
        public async Task<ActionResult<ServiceResult<ApplicationUserDto>>> AddFavoriteRestaurant(AddFavoriteRestaurantCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        //TODO: Command type update remove restaurant from favorites

        //TODO: Query Get restaurants by user favorite (en restaurantes)


    }
}
