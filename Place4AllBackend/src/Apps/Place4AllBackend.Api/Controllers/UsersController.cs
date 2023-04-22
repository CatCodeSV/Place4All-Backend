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

namespace Place4AllBackend.Api.Controllers
/// <summary>
/// Restaurants
/// </summary>
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        //TODO: Command type Update add restaurant to favorites

        //TODO: Command type update remove restaurant from favorites

        //TODO: Query Get restaurants by user favorite (en restaurantes)


    }
}
