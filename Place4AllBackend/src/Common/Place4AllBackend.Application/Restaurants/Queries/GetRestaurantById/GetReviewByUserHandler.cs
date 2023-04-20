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
using Place4AllBackend.Application.Reviews.Commands.Queries.GetByUser;

namespace Place4AllBackend.Application.Restaurants.Queries.GetRestaurantById;

public class GetReviewByUserHandler : IRequestHandlerWrapper<GetReviewByUser, List<ReviewDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetReviewByUserHandler(IApplicationDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ServiceResult<List<ReviewDto>>> Handle(GetReviewByUser request,
        CancellationToken cancellationToken)
    {
        var list = await _context.Reviews.Where(x => x.Creator == request.userId).Include(x => x.AdditionalFeatures)
            .Include(x => x.Restaurant).ProjectToType<ReviewDto>(_mapper.Config).ToListAsync(cancellationToken);

        return list.Count > 0
            ? ServiceResult.Success(list)
            : ServiceResult.Failed<List<ReviewDto>>(ServiceError.NotFound);
    }
}