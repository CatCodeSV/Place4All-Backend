using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Application.Features.Queries.GetFeatures;
using Place4AllBackend.Application.Restaurants.Queries.GetRestaurants;

namespace Place4AllBackend.Api.Controllers;

/// <summary>
/// Features
/// </summary>
public class FeaturesController : BaseApiController
{
    /// <summary>
    /// Get all Features
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<ServiceResult<List<FeatureDto>>>> GetAllFeatures(
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetAllFeaturesQuery(), cancellationToken));
    }
}