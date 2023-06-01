using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Application.Restaurants.Commands.Create;
using Place4AllBackend.Application.Restaurants.Queries.GetFavoritesRestaurants;
using Place4AllBackend.Application.Restaurants.Queries.GetRestaurantById;
using Place4AllBackend.Application.Restaurants.Queries.GetRestaurants;
using Place4AllBackend.Application.Restaurants.Queries.GetRestaurantsByFeatures;
using Place4AllBackend.Application.Restaurants.Queries.GetRestaurantsByQuery;

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
    public async Task<ActionResult<ServiceResult<List<RestaurantSummarizedDto>>>> GetAllRestaurants(
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetAllRestaurantsQuery(), cancellationToken));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("features")]
    public async Task<ActionResult<ServiceResult<List<RestaurantSummarizedDto>>>> GetRestaurantsByFeature(
        GetRestaurantsByFeatureQuery query, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetRestaurantsByFeatureQuery(), cancellationToken));
    }

    /// <summary>
    /// Get restaurant by Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ServiceResult<RestaurantDto>>> GetRestaurantById(int id,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetRestaurantByIdQuery { RestaurantId = id }, cancellationToken));
    }

    /// <summary>
    /// Get Restaurants by Query
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("Query")]
    public async Task<ActionResult<ServiceResult<List<RestaurantSummarizedDto>>>> Query(string query,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetRestaurantsByQuery() { Query = query }, cancellationToken));
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

    /// <summary>
    /// Get Restaurant List from Features
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("Features")]
    public async Task<ActionResult<ServiceResult<List<RestaurantSummarizedDto>>>> GetRestaurantsByFeatures(
        GetRestaurantsByFeatureQuery query, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(query, cancellationToken));
    }

    /// <summary>
    /// Get Favorite Restaurants
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("User")]
    public async Task<ActionResult<ServiceResult<List<RestaurantDto>>>> GetUserFavoriteRestaurants(
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetFavoriteRestaurantsQuery(), cancellationToken));
    }
}