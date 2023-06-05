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

namespace Place4AllBackend.Application.Services.Reservations.Commands.Create;

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
        var features = await _context.Features.Where(x => request.Features.Contains(x.Id))
            .ToListAsync(cancellationToken);

        var entity = new Reservation()
        {
            Features = features,
            Date = request.Date,
            People = request.People,
            SpecialInstructions = request.SpecialInstructions,
            RestaurantId = request.RestaurantId
        };

        var newEntity = await _context.Reservations.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return ServiceResult.Success(_mapper.Map<ReservationDto>(newEntity.Entity));
    }
}