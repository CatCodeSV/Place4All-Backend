using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Place4AllBackend.Application.Common.Exceptions;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public IdentityService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new UnauthorizeException();
            }

            return user.UserName;
        }

        public async Task<ApplicationUserDto> CheckUserPassword(string email, string password)
        {
            ApplicationUser user =
                await _userManager.Users.Include(x => x.Address).FirstOrDefaultAsync(u => u.Email == email);

            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return _mapper.Map<ApplicationUserDto>(user);
            }

            return null;
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
            };

            var result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<bool> UserIsInRole(string userId, string role)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            return await _userManager.IsInRoleAsync(user, role);
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                return await DeleteUserAsync(user);
            }

            return Result.Success();
        }

        public async Task<Result> DeleteUserAsync(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }

        public async Task<ApplicationUser> AddFavoriteRestaurant(Restaurant favoriteRestaurant, string userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) return null;
            user.FavoriteRestaurants.Add(favoriteRestaurant);
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded ? user : null;
        }

        public async Task<ApplicationUser> DeleteFavoriteRestaurant(Restaurant favoriteRestaurant, string userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) return null;
            user.FavoriteRestaurants.Remove(favoriteRestaurant);
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded ? user : null;
        }

        public async Task<ApplicationUser> GetCurrentUser(string userId)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == userId);

            return user ?? null;
        }
    }
}