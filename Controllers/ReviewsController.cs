using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers;


[ApiController]
[Route("Reviews")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewsService _reviewsService;

    public ReviewsController(IReviewsService reviewsService)
    {
        _reviewsService = reviewsService;
    }

    [HttpGet("/restaurants/{id:length(24)}")]
    public ActionResult<List<Reviews>> GetByRestaurant(string id)
    {
        var reviews = _reviewsService.GetByRestaurant(id);
        if (reviews == null || !reviews.Any())
        {
            return NotFound();
        }

        return reviews;
    }
    
    [HttpGet("/users/{id:length(24)}")]
    public ActionResult<List<Reviews>> GetByUser(string id)
    {
        var reviews = _reviewsService.GetByUser(id);
        if (reviews == null || !reviews.Any())
        {
            return NotFound();
        }

        return reviews;
    }
    
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Reviews>> Get(string id)
    {
        var review = await _reviewsService.GetById(id);
        if (review == null)
        {
            return NotFound();
        }

        return review;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Reviews>> Create(Reviews review)
    {
        var result = await _reviewsService.Create(review);
        return CreatedAtRoute("", new { id = result.Id }, result);
    }
}