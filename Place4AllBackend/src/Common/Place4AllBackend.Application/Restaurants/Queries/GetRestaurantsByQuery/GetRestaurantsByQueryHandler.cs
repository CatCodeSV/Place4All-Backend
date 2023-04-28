using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Restaurants.Queries.GetRestaurantsByQuery;

public class GetRestaurantsByQueryHandler : IRequestHandlerWrapper<GetRestaurantsByQuery, List<RestaurantDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRestaurantsByQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<List<RestaurantDto>>> Handle(GetRestaurantsByQuery request,
        CancellationToken cancellationToken)
    {
        var list = await _context.Restaurants
            .Include(r => r.Images)
            .Include(r => r.Address)
            .Include(r => r.Features)
            .Where(b =>
                b.Name.ToLower().Contains(request.Query.ToLower()) ||
                b.Address.Street.ToLower().Contains(request.Query.ToLower()) ||
                b.Address.City.ToLower().Contains(request.Query.ToLower()) ||
                b.Features.Any(f => f.Name.ToLower().Contains(request.Query)))
            .ProjectToType<RestaurantDto>(_mapper.Config).ToListAsync(cancellationToken);

        return list.Count > 0
            ? ServiceResult.Success(list)
            : ServiceResult.Failed<List<RestaurantDto>>(ServiceError.NotFound);
    }
}