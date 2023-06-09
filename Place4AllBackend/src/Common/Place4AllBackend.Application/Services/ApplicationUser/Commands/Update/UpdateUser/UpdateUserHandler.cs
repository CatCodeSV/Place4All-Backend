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

        public UpdateUserHandler (IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService, IIdentityService identityService)
        {
            _context = context;
            _mapper = mapper;
            _identityService = identityService;
        }

        public async Task<ServiceResult<ApplicationUserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _identityService.GetUserById(request.Id);
            if (userToUpdate == null)
            {
                return ServiceResult.Failed<ApplicationUserDto>(ServiceError.NotFound);
            }
            userToUpdate.Name = request.Name;
            userToUpdate.LastName = request.LastName;
            userToUpdate.Gender = request.Gender.ToString();
            userToUpdate.BirthDate = request.BirthDate;
            userToUpdate.HasDisability = request.HasDisability;
            userToUpdate.DisabilityType = request.DisabilityType;
            userToUpdate.DisabilityDegree = request.DisabilityDegree;

            await _context.SaveChangesAsync(cancellationToken);
            return ServiceResult.Success<ApplicationUserDto>(_mapper.Map<ApplicationUserDto>(userToUpdate));
        }
    }
}
