using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Place4AllBackend.Domain.Enums;

namespace Place4AllBackend.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Gsm { get; set; }
        
        public Gender Gender { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public int AddressId { get; set; }
        
        public Address Address { get; set; }
       
        public bool HasDisability { get; set; }
        
        public DisabilityType? DisabilityType { get; set; }
        
        public int? DisabilityDegree { get; set; }

        public IList<Restaurant> FavoriteRestaurants { get; set; } = new List<Restaurant>();
    }
}