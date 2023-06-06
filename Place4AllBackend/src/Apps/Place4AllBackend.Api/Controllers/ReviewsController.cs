using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Application.Reviews.Commands.Create;
using Place4AllBackend.Application.Reviews.Commands.Queries.GetByRestaurant;
using Place4AllBackend.Application.Reviews.Commands.Queries.GetByUser;
using Place4AllBackend.Application.Services.Reviews.Commands.Create;

namespace Place4AllBackend.Api.Controllers;

/// <summary>
/// Reviews
/// </summary>
[Authorize (Roles = "User")]
[Authorize (Roles = "Admin")]
public class ReviewsController : BaseApiController
{
    /// <summary>
    /// Create a new Review
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<ServiceResult<ReviewDto>>> Create(CreateReviewCommand command,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }

    /// <summary>
    /// Get Reviews by User
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("User")]
    public async Task<ActionResult<ServiceResult<List<ReviewDto>>>> GetByUser(
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetReviewsByUser(), cancellationToken));
    }

    /// <summary>
    /// Get Reviews by Restaurant
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("Restaurant/{id}"), AllowAnonymous]
    public async Task<ActionResult<ServiceResult<List<ReviewDto>>>> GetByRestaurant(int id,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetReviewsByRestaurant() { RestaurantId = id }, cancellationToken));
    }
}