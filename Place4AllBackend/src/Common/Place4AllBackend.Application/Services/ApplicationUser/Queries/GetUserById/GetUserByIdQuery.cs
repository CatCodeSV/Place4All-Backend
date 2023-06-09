using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Place4AllBackend.Application.Services.ApplicationUser.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequestWrapper<ApplicationUserDto>
    {
        public string UserId { get; set; }
    }
}
