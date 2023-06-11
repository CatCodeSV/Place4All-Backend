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
    public class UpdateUserHandler : IRequestHandlerWrapper<UpdateUserCommand, ApplicationUserDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;

        public UpdateUserHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService,
            IIdentityService identityService)
        {
            _context = context;
            _mapper = mapper;
            _identityService = identityService;
        }

        public async Task<ServiceResult<ApplicationUserDto>> Handle(UpdateUserCommand request,
            CancellationToken cancellationToken)
        {
            var updatedUser = await _identityService.UpdateUser(request);

            return updatedUser != null
                ? ServiceResult.Success<ApplicationUserDto>(updatedUser)
                : ServiceResult.Failed<ApplicationUserDto>(ServiceError.UserFailedtoUpdate);
        }
    }
}