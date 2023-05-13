using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.ApplicationUser.Queries.GetToken
{
    public class GetTokenQuery : IRequestWrapper<LoginResponse>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class GetTokenQueryHandler : IRequestHandlerWrapper<GetTokenQuery, LoginResponse>
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public GetTokenQueryHandler(IIdentityService identityService, ITokenService tokenService, IMapper mapper)
        {
            _identityService = identityService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<ServiceResult<LoginResponse>> Handle(GetTokenQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _identityService.CheckUserPassword(request.Email, request.Password);

            if (user == null)
                return ServiceResult.Failed<LoginResponse>(ServiceError.ForbiddenError);


            return ServiceResult.Success(new LoginResponse
            {
                User = _mapper.Map<ApplicationUserDto>(user),
                Token = _tokenService.CreateJwtSecurityToken(user.Id, user.UserName)
            });
        }
    }
}