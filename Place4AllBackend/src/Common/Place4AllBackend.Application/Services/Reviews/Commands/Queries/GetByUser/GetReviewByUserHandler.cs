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

namespace Place4AllBackend.Application.Reviews.Commands.Queries.GetByUser;

public class GetReviewByUserHandler : IRequestHandlerWrapper<GetReviewsByUser, List<ReviewDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public GetReviewByUserHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
    {
        _mapper = mapper;
        _context = context;
        _currentUserService = currentUserService;
    }

    public async Task<ServiceResult<List<ReviewDto>>> Handle(GetReviewsByUser request,
        CancellationToken cancellationToken)
    {
        var list = await _context.Reviews.Where(x => x.Creator == _currentUserService.UserId)
            .Include(x => x.AdditionalFeatures)
            .Include(x => x.Restaurant).ProjectTo<ReviewDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

        return list.Count > 0
            ? ServiceResult.Success(list)
            : ServiceResult.Failed<List<ReviewDto>>(ServiceError.NotFound);
    }
}