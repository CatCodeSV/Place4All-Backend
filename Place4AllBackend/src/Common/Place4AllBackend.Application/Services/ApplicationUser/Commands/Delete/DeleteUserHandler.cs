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

namespace Place4AllBackend.Application.Services.ApplicationUser.Commands.Delete
{
    public class DeleteUserHandler : IRequestHandlerWrapper<DeleteUserCommand, ApplicationUserDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;

        public DeleteUserHandler (IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService, IIdentityService identityService)
        {
            _context = context;
            _mapper = mapper;
            _identityService = identityService;
        }

        public async Task<ServiceResult<ApplicationUserDto>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userToDelete = await _identityService.GetUserById(request.Id);
            if (userToDelete == null)
            {
                return ServiceResult.Failed<ApplicationUserDto>(ServiceError.NotFound);
            }
            await _identityService.DeleteUserAsync(userToDelete.Id);
            await _context.SaveChangesAsync(cancellationToken);
            return ServiceResult.Success(_mapper.Map<ApplicationUserDto>(userToDelete));
        }
    }
}
