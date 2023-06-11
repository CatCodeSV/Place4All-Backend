using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Restaurants.Queries.GetRestaurantsByQuery;

public class GetRestaurantsByQueryHandler : IRequestHandlerWrapper<GetRestaurantsByQuery, List<RestaurantSummarizedDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRestaurantsByQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<List<RestaurantSummarizedDto>>> Handle(GetRestaurantsByQuery request,
        CancellationToken cancellationToken)
    {
        var list = await _context.Restaurants
            .Where(b =>
                b.Name.ToLower().Contains(request.Query.ToLower()) ||
                b.Address.Street.ToLower().Contains(request.Query.ToLower()) ||
                b.Address.City.ToLower().Contains(request.Query.ToLower()) ||
                b.Features.Any(f => f.Name.ToLower().Contains(request.Query)))
            .Include(b => b.Address)
            .Include(b => b.Reviews)
            .Include(b => b.Images)
            .ProjectTo<RestaurantSummarizedDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

        return list.Count > 0
            ? ServiceResult.Success(list)
            : ServiceResult.Failed<List<RestaurantSummarizedDto>>(ServiceError.NotFound);
    }
}