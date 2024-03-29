﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Restaurants.Queries.GetFavoritesRestaurants
{
    public class
        GetFavoriteRestaurantsHandler : IRequestHandlerWrapper<GetFavoriteRestaurantsQuery,
            List<RestaurantSummarizedDto>>
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


        public async Task<ServiceResult<List<RestaurantSummarizedDto>>> Handle(GetFavoriteRestaurantsQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _identityService.GetCurrentUser(_currentUserService.UserId);
            var list = await _context.Restaurants.Where(x => x.FavoriteUsers.Contains(user)).Include(x => x.Address)
                .Include(x => x.Features).Include(x => x.Images)
                .ProjectTo<RestaurantSummarizedDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return list.Count > 0
                ? ServiceResult.Success(list)
                : ServiceResult.Failed<List<RestaurantSummarizedDto>>(ServiceError.NotFound);
        }
    }
}
