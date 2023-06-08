using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Place4AllBackend.Application.Services.ApplicationUser.Commands.Update.UpdateUser
{
    internal class UpdateUserCommand : IRequestWrapper<ApplicationUserDto>
    {
        public string UserId { get; set; } 
    }
}
