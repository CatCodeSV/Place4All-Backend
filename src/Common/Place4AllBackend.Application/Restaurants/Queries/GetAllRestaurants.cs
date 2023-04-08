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

namespace Place4AllBackend.Application.Restaurants.Queries
{

    public class GetAllRestaurants : IRequestWrapper<List<RestaurantDto>>
    {
    }

    public class GetRestaurantsHandler : IRequestHandlerWrapper<GetAllRestaurants, List<RestaurantDto>>
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


        public async Task<ServiceResult<List<RestaurantDto>>> Handle(GetAllRestaurants request,
            CancellationToken cancellationToken)
        {
            List<RestaurantDto> list = new List<RestaurantDto>();
            try
            {
                var list1 = _context.Restaurants.Include(x => x.Address);
                var list2 = list1.ProjectToType<RestaurantDto>(_mapper.Config);
                list = await list2.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }

            return list.Count > 0
                ? ServiceResult.Success(list)
                : ServiceResult.Failed<List<RestaurantDto>>(ServiceError.NotFound);
        }
    }
}