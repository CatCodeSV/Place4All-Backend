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

namespace Place4AllBackend.Application.Reviews.Commands.Queries.GetByRestaurant;

public class GetReviewsByRestaurantHandler : IRequestHandlerWrapper<GetReviewsByRestaurant, List<ReviewDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identityService;

    public GetReviewsByRestaurantHandler(IApplicationDbContext context, IMapper mapper,
        IIdentityService identityService)
    {
        _context = context;
        _mapper = mapper;
        _identityService = identityService;
    }

    public async Task<ServiceResult<List<ReviewDto>>> Handle(GetReviewsByRestaurant request,
        CancellationToken cancellationToken)
    {
        var list = await _context.Reviews.Where(x => x.RestaurantId == request.RestaurantId)
            .Include(x => x.AdditionalFeatures)
            .Include(x => x.Restaurant).Select(x => new ReviewDto()
            {
                AdditionalFeatures = x.AdditionalFeatures,
                Comment = x.Comment,
                CreateDate = x.CreateDate.ToString("dd/MM/yyyy"),
                Creator = x.Creator,
                Id = x.Id,
                InformationAccuracy = x.InformationAccuracy,
                RestaurantId = x.RestaurantId,
                UserName = _identityService.GetUserNameAsync(x.Creator).Result,
                Value = x.Value,
                Title = x.Title
            }).ToListAsync(cancellationToken);

        return list.Count > 0
            ? ServiceResult.Success(list)
            : ServiceResult.Failed<List<ReviewDto>>(ServiceError.NotFound);
    }
}