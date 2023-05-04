using System.Collections.Generic;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Restaurants.Queries.GetRestaurantsByFeatures;

public class GetRestaurantsByFeatureQuery : IRequestWrapper<List<RestaurantSummarizedDto>>
{
    public List<int> Features { get; set; }
}