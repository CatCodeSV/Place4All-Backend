using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Application.Features.Queries.GetFeatures;

public class GetAllFeaturesHandler : IRequestHandlerWrapper<GetAllFeaturesQuery, List<FeatureDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllFeaturesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<List<FeatureDto>>> Handle(GetAllFeaturesQuery request,
        CancellationToken cancellationToken)
    {
        var list = await _context.Features.ProjectTo<FeatureDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

        return list.Count > 0
            ? ServiceResult.Success(list)
            : ServiceResult.Failed<List<FeatureDto>>(ServiceError.NotFound);
    }
}