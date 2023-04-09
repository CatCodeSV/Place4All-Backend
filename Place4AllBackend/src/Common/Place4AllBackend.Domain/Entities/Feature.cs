using System.Collections.Generic;
using Place4AllBackend.Domain.Common;

namespace Place4AllBackend.Domain.Entities
{
    public class Feature : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Restaurant> Restaurants { get; set; }
        public IList<Reservation> Reservations { get; set; }
    }
}