using System.Collections.Generic;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Reviews.Commands.Queries.GetByRestaurant;

public class GetReviewsByRestaurant : IRequestWrapper<List<ReviewDto>>
{
    public int RestaurantId { get; set; }
}