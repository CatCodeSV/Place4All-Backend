using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Restaurants.Queries.GetRestaurants
{
    public class GetAllRestaurantsQuery : IRequestWrapper<List<RestaurantSummarizedDto>>
    {
    }

    public class GetRestaurantsHandler : IRequestHandlerWrapper<GetAllRestaurantsQuery, List<RestaurantSummarizedDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRestaurantsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ServiceResult<List<RestaurantSummarizedDto>>> Handle(GetAllRestaurantsQuery request,
            CancellationToken cancellationToken)
        {
            var list = await _context.Restaurants.Include(x => x.Images).Include(x => x.Address).Include(x => x.Reviews)
                .ProjectTo<RestaurantSummarizedDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return list.Count > 0
                ? ServiceResult.Success(list)
                : ServiceResult.Failed<List<RestaurantSummarizedDto>>(ServiceError.NotFound);
        }
    }
}