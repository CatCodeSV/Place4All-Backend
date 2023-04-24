using System.Collections.Generic;
using Place4AllBackend.Domain.Common;

namespace Place4AllBackend.Domain.Entities
{
    public class Restaurant : AuditableEntity
    {
        public Restaurant()
        {
            Features = new List<Feature>();
            Images = new List<Image>();
        }
        public int Id { get; set; }

        public string Name { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public IList<Image> Images { get; set; }
        public IList<Feature> Features { get; set; }
        public IList<ApplicationUser> FavoriteUsers { get; set; } = new List<ApplicationUser>();
    }
}