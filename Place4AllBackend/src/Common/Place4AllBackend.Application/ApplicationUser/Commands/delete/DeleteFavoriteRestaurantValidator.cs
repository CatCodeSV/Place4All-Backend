using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.ApplicationUser.Commands.Update;
using Place4AllBackend.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Place4AllBackend.Application.ApplicationUser.Commands.Delete
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
            RuleFor(x => x.FavoriteRestaurantId).MustAsync((y, token) => _context.Restaurants.AnyAsync(z => z.Id == y, token)).WithMessage(a => $"El restaurante con el identificador {a.FavoriteRestaurantId} no existe.");
        }
    }
}
