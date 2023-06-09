using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Place4AllBackend.Application.Services.ApplicationUser.Commands.Update.UpdateUser
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _identityService;

        public UpdateUserValidator(IApplicationDbContext context, IIdentityService identityService)
        {
            _context = context;
            _identityService = identityService;
            AddValidationRules();
        }

        private void AddValidationRules()
        {
        }
    }
}
