using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;

namespace Place4AllBackend.Application.Common.Interfaces
{
    public interface ITokenService
    {
        string CreateJwtSecurityToken(string id, string userName, List<string> roles);

        public void GetClaimsAsync( List<Claims> authClaims) { }
    }
}