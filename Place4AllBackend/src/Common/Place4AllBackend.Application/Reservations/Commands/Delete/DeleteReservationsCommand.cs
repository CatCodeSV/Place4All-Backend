using MapsterMapper;
using MediatR;
using MediatR.Wrappers;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Exceptions;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Place4AllBackend.Application.Reservations.Commands.Delete
{
    internal class DeleteReservationsCommand : IRequestWrapper<ReservationDto>
    {
        public int Id { get; set; }
    }

    public class DeleteReservationsCommandHandler : IRequestHandlerWrapper<DeleteReservationsCommand, ReservationDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteReservationsCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        async Task<ServiceResult<ReservationDto>> IRequestHandler<DeleteReservationsCommand, ServiceResult<ReservationDto>>.Handle(DeleteReservationsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Reservations
                .Where(x => x.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(City), request.Id);
            }

            _context.Reservations.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return ServiceResult.Success(_mapper.Map<ReservationDto>(entity));

        }
    }
}
