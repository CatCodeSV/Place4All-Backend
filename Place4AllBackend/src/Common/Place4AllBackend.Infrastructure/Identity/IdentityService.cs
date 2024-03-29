﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Place4AllBackend.Application.Common.Exceptions;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Services.ApplicationUser.Commands.Create;
using Place4AllBackend.Application.Services.ApplicationUser.Commands.Update.UpdateUser;
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

        public async Task<(Result Result, string UserId)> CreateUserAsync(CreateUserCommand command)
        {
            var user = new ApplicationUser
            {
                UserName = command.Email,
                Email = command.Email,
                Address = new Address()
                {
                    Street = command.Street,
                    Number = command.Number,
                    ZipCode = command.ZipCode,
                    City = command.City,
                    Province = command.Province,
                },
                Name = command.Name,
                LastName = command.LastName,
                Gender = command.Gender,
                DisabilityDegree = command.DisabilityDegree,
                HasDisability = command.HasDisability,
                PhoneNumber = command.PhoneNumber,
                BirthDate = command.BirthDate
            };

            var result = await _userManager.CreateAsync(user, command.Password);

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

        public async Task<List<ApplicationUserDto>> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<List<ApplicationUserDto>>(users);
        }

        public async Task<IList<string>> GetRolesAsync(string userId)
        {
            var user = await GetCurrentUser(userId);
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<ApplicationUserDto> GetUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return _mapper.Map<ApplicationUserDto>(user);
        }

        public async Task<ApplicationUserDto> UpdateUser(UpdateUserCommand user)
        {
            var userToUpdate = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

            if (userToUpdate == null) return null;

            userToUpdate.Name = user.Name;
            userToUpdate.Name = user.Name;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Gender = user.Gender;
            userToUpdate.BirthDate = user.BirthDate;
            userToUpdate.HasDisability = user.HasDisability;
            userToUpdate.DisabilityType = user.DisabilityType;
            userToUpdate.DisabilityDegree = user.DisabilityDegree;
            userToUpdate.UserName = user.UserName;

            var result = await _userManager.UpdateAsync(userToUpdate);
            return result.Succeeded ? _mapper.Map<ApplicationUserDto>(userToUpdate) : null;
        }
    }
}