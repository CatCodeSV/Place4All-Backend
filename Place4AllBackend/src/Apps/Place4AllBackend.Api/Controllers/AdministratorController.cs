using Microsoft.AspNetCore.Authorization;

namespace Place4AllBackend.Api.Controllers
{
    [Authorize (Roles = "Administrator")]
    public class AdministratorController : BaseApiController
    {
    }
}
