using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Interfaces;

namespace Place4AllBackend.Application.ApplicationUser.Commands.Update.AddFavoriteRestaurant
{
    public class AddFavoriteRestaurantValidator : AbstractValidator<AddFavoriteRestaurantCommand>
    {
        private readonly IApplicationDbContext _context;

        public AddFavoriteRestaurantValidator(IApplicationDbContext context)
        {
            _context = context;
            AddValidationRules();
        }

        private void AddValidationRules()
        {
            RuleFor(x => x.FavoriteRestaurantId).MustAsync((y, token) => _context.Restaurants.AnyAsync(z => z.Id == y, token)).WithMessage(a => $"El restaurante con el identificacor {a.FavoriteRestaurantId} no existe.");
        }
    }
}
