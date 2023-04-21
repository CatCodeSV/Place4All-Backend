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

namespace Place4AllBackend.Application.Reservations.Queries.GetReservationByIdUser
{
        internal class GetReservationByIdUserQuery : IRequestWrapper<ReservationDto>
    {
        public string ApplicationUserId { get; set; }
        //si pongo un string no me deja compararlo con un int (x.Id == request.ApplicationUserId)
    }
    public class GetReservationByIdUserQueryHandler : IRequestHandlerWrapper<GetReservationByIdUserQuery, ReservationDto> 
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetReservationByIdUserQueryHandler(IApplicationDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;

        }

        async Task<ServiceResult<ReservationDto>> IRequestHandler<GetReservationByIdUserQuery, ServiceResult<ReservationDto>>.Handle(GetReservationByIdUserQuery request, CancellationToken cancellationToken)
        {
            var ApplicationUser = await _context.Reservations
                .Where(x => x.Creator == request.ApplicationUserId)
                .Include(r => r.Restaurant)
                .ProjectToType<ReservationDto>(_mapper.Config)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }


}
