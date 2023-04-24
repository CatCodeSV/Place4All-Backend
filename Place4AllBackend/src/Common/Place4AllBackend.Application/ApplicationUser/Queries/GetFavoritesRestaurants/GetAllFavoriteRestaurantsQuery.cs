using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public GetFavoriteRestaurantsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<RestaurantDto>>> Handle(GetAllFavoriteRestaurantsQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.Restaurants.Include(a => a.Name).ToListAsync(cancellationToken);
            
            return list.Count>0
                ? ServiceResult.Success(list)
                : ServiceResult.Failed<List<RestaurantDto>>(ServiceError.NotFound);
        }
    }
}
