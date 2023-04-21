﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Reservations.Queries.GetReservationByUser
{
    public class GetReservationByUserQueryHandler : IRequestHandlerWrapper<GetReservationByUserQuery,
        List<ReservationDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetReservationByUserQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<ServiceResult<List<ReservationDto>>> Handle(GetReservationByUserQuery request,
            CancellationToken cancellationToken)
        {
            var list = await _context.Reservations.Where(x => x.Creator == request.ApplicationUserId)
                .Include(f => f.Features)
                .Include(r => r.Restaurant)
                .ThenInclude(r => r.Address)
                .ProjectToType<ReservationDto>(_mapper.Config)
                .ToListAsync(cancellationToken);

            return list.Count > 0
                ? ServiceResult.Success(list)
                : ServiceResult.Failed<List<ReservationDto>>(ServiceError.NotFound);
        }
    }
}