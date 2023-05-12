using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Application.Reservations.Commands.Create;

public class CreateReservationCommandHandler : IRequestHandlerWrapper<CreateReservationCommand, ReservationDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateReservationCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ServiceResult<ReservationDto>> Handle(CreateReservationCommand request,
        CancellationToken cancellationToken)
    {
        var entity = new Reservation()
        {
            Features = new List<Feature>(),
            Date = request.Date,
            People = request.People,
            SpecialInstructions = request.SpecialInstructions,
            RestaurantId = request.RestaurantId
        };

        await _context.Reservations.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return ServiceResult.Success(_mapper.Map<ReservationDto>(entity));
    }
}