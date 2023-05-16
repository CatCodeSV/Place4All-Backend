using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Place4AllBackend.Application.ApplicationUser.Queries.GetToken;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Services.ApplicationUser.Commands.Create;

public class CreateUserCommandHandler : IRequestHandlerWrapper<CreateUserCommand, LoginResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IIdentityService _identityService;
    private readonly ITokenService _tokenService;
    private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;

    public CreateUserCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger logger,
        IIdentityService identityService, ITokenService tokenService,
        UserManager<Domain.Entities.ApplicationUser> userManager)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
        _identityService = identityService;
        _tokenService = tokenService;
        _userManager = userManager;
    }

    public async Task<ServiceResult<LoginResponse>> Handle(CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _identityService.CreateUserAsync(request);
        if (result.Result.Succeeded)
        {
            _logger.LogInformation("User created a new account with password");
            var user = await _identityService.CheckUserPassword(request.Email, request.Password);

            if (user == null)
            {
                return ServiceResult.Failed<LoginResponse>(ServiceError.ForbiddenError);
            }

            await _userManager.AddToRolesAsync(await _identityService.GetCurrentUser(user.Id),
                new[] { "User" });

            return ServiceResult.Success(new LoginResponse
            {
                User = _mapper.Map<ApplicationUserDto>(user),
                Token = _tokenService.CreateJwtSecurityToken(user.Id, user.UserName)
            });
        }

        foreach (var error in result.Result.Errors)
        {
            _logger.LogError(error, error);
        }

        return ServiceResult.Failed<LoginResponse>(ServiceError.UserNotFound);
    }
}