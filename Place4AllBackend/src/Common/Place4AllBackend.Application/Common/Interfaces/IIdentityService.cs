using System.Threading.Tasks;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<ApplicationUserDto> CheckUserPassword(string userName, string password);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<bool> UserIsInRole(string userId, string role);

        Task<Result> DeleteUserAsync(string userId);

        Task<Domain.Entities.ApplicationUser> AddFavoriteRestaurant(Restaurant favoriteRestaurant, string userId);

        Task<Domain.Entities.ApplicationUser> DeleteFavoriteRestaurant(Restaurant favoriteRestaurant, string userId);

        Task<Domain.Entities.ApplicationUser> GetCurrentUser(string userId);
    }
}