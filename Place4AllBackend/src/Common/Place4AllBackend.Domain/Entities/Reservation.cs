using System;
using System.Collections.Generic;
using Place4AllBackend.Domain.Common;

namespace Place4AllBackend.Domain.Entities
{
    public class Reservation : AuditableEntity
    {
        public Reservation()
        {
            Features = new List<Feature>();
        }
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int People { get; set; }
        public IList<Feature> Features { get; set; }
        public string SpecialInstructions { get; set; }
        public DateTime Date { get; set; }
    }
}