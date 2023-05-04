using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Interfaces;

namespace Place4AllBackend.Application.ApplicationUser.Commands.Update.RemoveFavoriteRestaurant
{
    internal class DeleteFavoriteRestaurantValidator : AbstractValidator<DeleteFavoriteRestaurantCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteFavoriteRestaurantValidator(IApplicationDbContext context)
        {
            _context = context;
            AddValidationRules();
        }

        private void AddValidationRules()
        {
            RuleFor(x => x.FavoriteRestaurantId)
                .MustAsync((y, token) => _context.Restaurants.AnyAsync(z => z.Id == y, token)).WithMessage(a =>
                    $"El restaurante con el identificador {a.FavoriteRestaurantId} no existe.");
            //TODO Añadir validación que el restaurante que se quiere eliminar está en la lista.
        }
    }
}
