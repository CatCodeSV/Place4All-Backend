namespace Place4AllBackend.Application.Common.Interfaces
{
    public interface ITokenService
    {
        string CreateJwtSecurityToken(string id);
    }
}