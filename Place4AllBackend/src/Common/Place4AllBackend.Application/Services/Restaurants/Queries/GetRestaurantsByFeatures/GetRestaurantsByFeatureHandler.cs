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

namespace Place4AllBackend.Application.Restaurants.Queries.GetRestaurantsByFeatures;

public class
    GetRestaurantsByFeatureHandler : IRequestHandlerWrapper<GetRestaurantsByFeatureQuery, List<RestaurantSummarizedDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRestaurantsByFeatureHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<List<RestaurantSummarizedDto>>> Handle(GetRestaurantsByFeatureQuery request,
        CancellationToken cancellationToken)
    {
        var list = await _context.Restaurants.Where(r => r.Features.Any(f => request.Features.Contains(f.Id)))
            .Include(x => x.Address).Include(x => x.Images).Include(x => x.Reviews)
            .ProjectTo<RestaurantSummarizedDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

        return list.Count > 0
            ? ServiceResult.Success(list)
            : ServiceResult.Failed<List<RestaurantSummarizedDto>>(ServiceError.NotFound);
    }
}