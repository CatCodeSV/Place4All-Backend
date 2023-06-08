using AutoMapper;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Application.Services.ApplicationUser.Queries.GetAllUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Place4AllBackend.Application.Services.ApplicationUser.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandlerWrapper<GetUserByIdQuery, ApplicationUserDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IApplicationDbContext context, IIdentityService identityService, IMapper mapper)
        {
            _context = context;
            _identityService = identityService;
            _mapper = mapper;
        }

        public async Task<ServiceResult<ApplicationUserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _identityService.GetUserById(request.UserId);
            if (user == null)
            {
                return ServiceResult.Failed<ApplicationUserDto>(ServiceError.NotFound);
            }

            return ServiceResult.Success(user);
        }
    }
}
