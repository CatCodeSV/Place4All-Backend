using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Place4AllBackend.Application.Services.ApplicationUser.Commands.Update.UpdateUser
{
    public class UpdateUserCommand : IRequestWrapper<ApplicationUserDto>
    {
        public string Id { get; set; } 
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public bool HasDisability { get; set; }
        public DisabilityType DisabilityType { get; set; }
        public int? DisabilityDegree { get; set; }
    }
}
