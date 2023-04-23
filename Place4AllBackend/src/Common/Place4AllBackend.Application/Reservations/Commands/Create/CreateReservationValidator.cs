using System;
using System.Linq;
using FluentValidation;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Interfaces;

namespace Place4AllBackend.Application.Reservations.Commands.Create;

public class CreateReservationValidator : AbstractValidator<CreateReservationCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateReservationValidator(IApplicationDbContext context)
    {
        _context = context;
        AddValidationRules();
    }

    private void AddValidationRules()
    {
        RuleFor(x => x.RestaurantId)
            .MustAsync((restaurantId, token) => _context.Restaurants.AnyAsync(x => x.Id == restaurantId, token))
            .WithMessage((data) => $"El restaurante con el identificador {data.RestaurantId} no existe");
        RuleFor(x => x.People).GreaterThan(0)
            .WithMessage("Debe haber al menos una persona en la reserva");
        RuleFor(x => x.Date).GreaterThanOrEqualTo(DateTime.Now.Date)
            .WithMessage("La reserva no puede estar en el pasado.");
    }
}