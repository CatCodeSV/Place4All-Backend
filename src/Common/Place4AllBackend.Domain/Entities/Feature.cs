using System.Collections.Generic;
using Place4AllBackend.Domain.Common;

namespace Place4AllBackendAyti.Domain.Entities
{
    public class Feature : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}