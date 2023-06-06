using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Services.ApplicationUser.Queries.GetAllUsers;

public class GetAllUsersHandler : IRequestHandlerWrapper<GetAllUsersQuery, List<ApplicationUserDto>>
{
    private readonly IIdentityService _identityService;
    
    public GetAllUsersHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    
    public async Task<ServiceResult<List<ApplicationUserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var list = await _identityService.GetAllUsers();
        
        return list != null ? ServiceResult.Success(list) : ServiceResult.Failed<List<ApplicationUserDto>>(ServiceError.NotFound);
    }
}