using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Place4AllBackend.Application.Services.Restaurants.Commands.Delete
{
    public class DeleteRestaurantValidator : AbstractValidator<DeleteRestaurantCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRestaurantValidator(IApplicationDbContext context)
        {
            _context = context;
            AddValidationRules();
        }

        private void AddValidationRules()
        {
            RuleFor(x => x.Id).MustAsync((y, token) => _context.Restaurants.AnyAsync(z => z.Id == y, token)).WithMessage(a => $"El restaurante con el identificacor {a.Id} no existe.");
        }
    }
}
