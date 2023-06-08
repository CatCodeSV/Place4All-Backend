using FluentValidation;
using Place4AllBackend.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Place4AllBackend.Application.Services.ApplicationUser.Commands.Delete
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteUserValidator(IApplicationDbContext context)
        {
            _context = context;
            AddValidationRules();
        }

        private void AddValidationRules()
        {
            throw new NotImplementedException();
        }
    }
}
