﻿using Microsoft.AspNetCore.Identity;
using Place4AllBackend.Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Place4AllBackend.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Gsm { get; set; }
        
        public string Gender { get; set; }
        
        public int Age { get; set; }
        
        public int AddressId { get; set; }
        
        public Address Address { get; set; }
       
        public bool HasDisability { get; set; }
        
        public int? DisabilityDegree { get; set; }

        public IList<Restaurant> FavoriteRestaurants { get; set; }
    }
}