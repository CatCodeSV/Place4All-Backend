using Place4AllBackend.Domain.Entities;
using System.Collections.Generic;

namespace Place4AllBackend.Application.Dto
{
    public class ApplicationUserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int AddressId { get; set; }
        public AddressDto Address { get; set; }
        public bool HasDisability { get; set; }
        public int? DisabilityDegree { get; set; }
    }
}