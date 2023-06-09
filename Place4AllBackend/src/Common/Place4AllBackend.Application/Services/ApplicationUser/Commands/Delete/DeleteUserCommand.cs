using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Place4AllBackend.Application.Services.ApplicationUser.Commands.Delete
{
    public class DeleteUserCommand : IRequestWrapper<ApplicationUserDto>
    {
        public string Id { get; set; }
    }
}
