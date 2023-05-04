using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuery : IRequestWrapper<RestaurantDto>
    {
        public int RestaurantId { get; set; }
    }

    public class GetRestaurantByIdQueryHandler : IRequestHandlerWrapper<GetRestaurantByIdQuery, RestaurantDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRestaurantByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        async Task<ServiceResult<RestaurantDto>> IRequestHandler<GetRestaurantByIdQuery, ServiceResult<RestaurantDto>>.
            Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await _context.Restaurants.Where(x => x.Id == request.RestaurantId).Include(a => a.Address)
                .Include(f => f.Features).Include(r => r.Reviews).Include(i => i.Images)
                .ProjectToType<RestaurantDto>(_mapper.Config)
                .FirstOrDefaultAsync(cancellationToken);
            
            if (restaurant != null)
            {
                restaurant.NumberOfReviews = restaurant.Reviews.Count;
                restaurant.Rating = restaurant.Reviews.Average(r => r.Value);
            }

            return restaurant != null
                ? ServiceResult.Success(restaurant)
                : ServiceResult.Failed<RestaurantDto>(ServiceError.NotFound);
        }
    }
}