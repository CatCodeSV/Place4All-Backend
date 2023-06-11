using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Services.Reviews.Commands.Create;

namespace Place4AllBackend.Application.Reviews.Commands.Create;

public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
{
    private readonly IApplicationDbContext _context;
    
    public CreateReviewCommandValidator(IApplicationDbContext context)
    {
        _context = context;
        AddValidationRules();
    }

    private void AddValidationRules()
    {
        RuleFor(x => x.Comment).MaximumLength(2000)
            .WithMessage("El comentario no puede superar los 2000 caracteres.");
        RuleFor(x => x.Value).LessThanOrEqualTo(5).GreaterThanOrEqualTo(0)
            .WithMessage("La valoración debe ser un valor entre 0 y 5.");
        RuleFor(x => x.RestaurantId).MustAsync((restaurantId, token) =>
            _context.Restaurants.AnyAsync(x => x.Id == restaurantId, token)).WithMessage((data) =>
            $"El restaurante con el identificador {data.RestaurantId} no existe.");
    }
}