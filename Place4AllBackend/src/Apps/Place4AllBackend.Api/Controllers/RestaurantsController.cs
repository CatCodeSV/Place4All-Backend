using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Application.Restaurants.Commands.Create;
using Place4AllBackend.Application.Restaurants.Queries;

namespace Place4AllBackend.Api.Controllers;

/// <summary>
/// Restaurants
/// </summary>
public class RestaurantsController : BaseApiController
{
    /// <summary>
    /// Get all Restaurants
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<ServiceResult<List<RestaurantDto>>>> GetAllRestaurants(
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetAllRestaurants(), cancellationToken));
    }
    
    /// <summary>
    /// Create restaurant
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<ServiceResult<RestaurantDto>>> Create(CreateRestaurantCommand command,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }
}