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
using Mapster;

namespace Place4AllBackend.Application.ApplicationUser.Queries.GetFavoritesRestaurants
{
    public class GetAllFavoriteRestaurantsQuery : IRequestWrapper<List<RestaurantDto>>
    {
    }

    public class
        GetFavoriteRestaurantsHandler : IRequestHandlerWrapper<GetAllFavoriteRestaurantsQuery, List<RestaurantDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public GetFavoriteRestaurantsHandler(IApplicationDbContext context, IMapper mapper,
            ICurrentUserService currentUserService, IIdentityService identityService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }


        public async Task<ServiceResult<List<RestaurantDto>>> Handle(GetAllFavoriteRestaurantsQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _identityService.GetFavoriteRestaurants(_currentUserService.UserId);
            var list = await _context.Restaurants.Where(x => x.FavoriteUsers.Contains(user)).Include(x => x.Address)
                .Include(x => x.Features).Include(x => x.Images).ProjectToType<RestaurantDto>(_mapper.Config)
                .ToListAsync(cancellationToken);
            return list.Count > 0
                ? ServiceResult.Success(list)
                : ServiceResult.Failed<List<RestaurantDto>>(ServiceError.NotFound);
        }
    }
}
