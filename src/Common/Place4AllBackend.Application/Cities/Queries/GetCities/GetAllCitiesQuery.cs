﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Place4AllBackend.Application.Cities.Queries.GetCities
{
    public class GetAllCitiesQuery : IRequestWrapper<List<CityDto>>
    {
    }

    public class GetCitiesQueryHandler : IRequestHandlerWrapper<GetAllCitiesQuery, List<CityDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCitiesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<CityDto>>> Handle(GetAllCitiesQuery request,
            CancellationToken cancellationToken)
        {
            List<CityDto> list = await _context.Cities
                .Include(x => x.Districts)
                .ThenInclude(c => c.Villages)
                .ProjectToType<CityDto>(_mapper.Config)
                .ToListAsync(cancellationToken);

            return list.Count > 0
                ? ServiceResult.Success(list)
                : ServiceResult.Failed<List<CityDto>>(ServiceError.NotFound);
        }
    }
}