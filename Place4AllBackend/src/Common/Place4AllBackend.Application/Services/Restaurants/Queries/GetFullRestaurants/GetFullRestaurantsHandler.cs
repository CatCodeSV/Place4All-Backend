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
using Place4AllBackend.Application.Restaurants.Queries.GetRestaurants;

namespace Place4AllBackend.Application.Services.Restaurants.Queries.GetFullRestaurants;

public class GetFullRestaurantsHandler : IRequestHandlerWrapper<GetFullRestaurantsQuery, List<RestaurantDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identityService;

    public GetFullRestaurantsHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identityService)
    {
        _context = context;
        _mapper = mapper;
        _identityService = identityService;
    }

    public async Task<ServiceResult<List<RestaurantDto>>> Handle(GetFullRestaurantsQuery request,
        CancellationToken cancellationToken)
    {
        var list = _context.Restaurants.Include(x => x.Features).Include(x => x.Images)
            .Include(x => x.Address).Include(x => x.Reviews);

        foreach (var entity in list)
        {
            if (entity.Creator == null)
            {
                continue;
            }

            var userName = await _identityService.GetUserNameAsync(entity.Creator);
            entity.Creator = userName;
        }

        var mappedList = await list.Select(entity => _mapper.Map<RestaurantDto>(entity)).ToListAsync();


        return mappedList.Count > 0
            ? ServiceResult.Success(mappedList)
            : ServiceResult.Failed<List<RestaurantDto>>(ServiceError.NotFound);
    }
}