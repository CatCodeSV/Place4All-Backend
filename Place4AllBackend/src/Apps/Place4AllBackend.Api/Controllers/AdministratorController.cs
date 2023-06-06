using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Application.Services.ApplicationUser.Queries.GetAllUsers;

namespace Place4AllBackend.Api.Controllers
{
    /// <summary>
    /// Administrator
    /// </summary>
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : BaseApiController
    {
        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns></returns>
        [HttpGet("/users")]
        public async Task<ActionResult<ServiceResult<List<ApplicationUserDto>>>> AddFavoriteRestaurant()
        {
            return Ok(await Mediator.Send(new GetAllUsersQuery()));
        }
    }
}