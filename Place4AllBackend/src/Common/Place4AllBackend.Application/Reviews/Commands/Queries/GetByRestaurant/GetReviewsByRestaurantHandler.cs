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

namespace Place4AllBackend.Application.Reviews.Commands.Queries.GetByRestaurant;

public class GetReviewsByRestaurantHandler : IRequestHandlerWrapper<GetReviewsByRestaurant, List<ReviewDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetReviewsByRestaurantHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<List<ReviewDto>>> Handle(GetReviewsByRestaurant request,
        CancellationToken cancellationToken)
    {
        var list = await _context.Reviews.Where(x => x.RestaurantId == request.RestaurantId)
            .Include(x => x.AdditionalFeatures)
            .Include(x => x.Restaurant).ProjectToType<ReviewDto>(_mapper.Config).ToListAsync(cancellationToken);

        return list.Count > 0
            ? ServiceResult.Success(list)
            : ServiceResult.Failed<List<ReviewDto>>(ServiceError.NotFound);
    }
}