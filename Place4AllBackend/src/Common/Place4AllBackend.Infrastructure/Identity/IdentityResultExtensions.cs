using System.Linq;
using Place4AllBackend.Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace Place4AllBackend.Infrastructure.Identity
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}