using MapsterMapper;
using Microsoft.Extensions.Logging;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Place4AllBackend.Application.ApplicationUser.Queries.GetFavoritesRestaurants
{
    public class GetAllFavoriteRestaurantsQuery : IRequestWrapper<List<RestaurantDto>>
    {
    }

    public class GetRestaurantsHandler : IRequestHandlerWrapper<GetAllFavoriteRestaurantsQuery, List<RestaurantDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public Task<ServiceResult<List<RestaurantDto>>> Handle(GetAllFavoriteRestaurantsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
