using AutoMapper;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Place4AllBackend.Application.Services.ApplicationUser.Commands.Update.UpdateUser
{
    internal class UpdateUserHandler : IRequestHandlerWrapper<UpdateUserCommand, ApplicationUserDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public UpdateUserHandler (IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService, IIdentityService identityService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task<ServiceResult<ApplicationUserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _identityService.
        }
    }
}
