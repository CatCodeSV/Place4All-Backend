using System.Collections.Generic;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Restaurants.Queries.GetRestaurantsByQuery;

public class GetRestaurantsByQuery : IRequestWrapper<List<RestaurantDto>>
{
    public string Query { get; set; }
}