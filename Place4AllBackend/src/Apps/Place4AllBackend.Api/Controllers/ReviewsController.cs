using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Application.Reviews.Commands.Create;

namespace Place4AllBackend.Api.Controllers;

/// <summary>
/// Reviews
/// </summary>
[Authorize]
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
}