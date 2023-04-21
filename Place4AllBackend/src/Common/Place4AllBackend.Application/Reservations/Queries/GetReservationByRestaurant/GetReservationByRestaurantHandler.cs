using Mapster;
using MapsterMapper;
using MediatR;
using MediatR.Wrappers;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Place4AllBackend.Application.Reservations.Queries.GetReservationByRestaurant
{
    public class GetReservationByRestaurantQueryHandler : IRequestHandlerWrapper<GetReservationByRestaurantQuery, List<ReservationDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetReservationByRestaurantQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<ServiceResult<List<ReservationDto>>> Handle(GetReservationByRestaurantQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.Reservations
                .Where(x => x.RestaurantId == request.RestaurantId)
                .Include(f => f.Features)
                .Include(r => r.Restaurant)
                .ThenInclude(a => a.Address)
                .ProjectToType<ReservationDto>(_mapper.Config)
                .ToListAsync(cancellationToken);

            return list.Count > 0
                ? ServiceResult.Success(list)
                : ServiceResult.Failed<List<ReservationDto>>(ServiceError.NotFound);
        }
    }
}
