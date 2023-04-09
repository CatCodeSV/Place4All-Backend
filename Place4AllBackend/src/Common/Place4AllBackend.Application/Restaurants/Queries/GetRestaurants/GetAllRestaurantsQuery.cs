using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Application.Restaurants.Queries.GetRestaurants
{

    public class GetAllRestaurantsQuery : IRequestWrapper<List<RestaurantDto>>
    {
    }

    public class GetRestaurantsHandler : IRequestHandlerWrapper<GetAllRestaurantsQuery, List<RestaurantDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<Restaurant> _logger;

        public GetRestaurantsHandler(IApplicationDbContext context, IMapper mapper, ILogger<Restaurant> logger)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }


        public async Task<ServiceResult<List<RestaurantDto>>> Handle(GetAllRestaurantsQuery request,
            CancellationToken cancellationToken)
        {
            var list = await _context.Restaurants.Include(a => a.Address).Include(i => i.Images)
                .Include(f => f.Features).ProjectToType<RestaurantDto>(_mapper.Config).ToListAsync(cancellationToken);

            return list.Count > 0
                ? ServiceResult.Success(list)
                : ServiceResult.Failed<List<RestaurantDto>>(ServiceError.NotFound);
        }
    }
}