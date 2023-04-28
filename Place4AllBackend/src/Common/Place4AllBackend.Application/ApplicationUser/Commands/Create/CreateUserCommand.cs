using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Place4AllBackend.Application.ApplicationUser.Queries.GetToken;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.ApplicationUser.Commands.Create;

public record CreateUserCommand(string Email, string Password ) : IRequestWrapper<LoginResponse>;

public class CreateUserCommandHandler : IRequestHandlerWrapper<CreateUserCommand, LoginResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<ApplicationUserDto> _logger;
    private readonly IIdentityService _identityService;
    private readonly ITokenService _tokenService;

    public CreateUserCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<ApplicationUserDto> logger,
        IIdentityService identityService, ITokenService tokenService)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
        _identityService = identityService;
        _tokenService = tokenService;
    }

    public async Task<ServiceResult<LoginResponse>> Handle(CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _identityService.CreateUserAsync(request.Email, request.Password);
        if (result.Result.Succeeded)
        {
            _logger.LogInformation("User created a new account with password");
            var user = await _identityService.CheckUserPassword(request.Email, request.Password);

            if (user == null)
                return ServiceResult.Failed<LoginResponse>(ServiceError.ForbiddenError);


            return ServiceResult.Success(new LoginResponse
            {
                User = user,
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