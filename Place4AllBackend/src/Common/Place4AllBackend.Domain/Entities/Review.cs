using System.Collections.Generic;
using Place4AllBackend.Domain.Common;

namespace Place4AllBackend.Domain.Entities
{
    public class Review : AuditableEntity
    {
        public int Id { get; set; }
        public float Value { get; set; }
        public string Comment { get; set; }
        public InformationAccuracy InformationAccuracy { get; set; }
        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }
        public List<Feature> AdditionalFeatures { get; set; }
    }

    public enum InformationAccuracy
    {
        VeryGood = 1,
        Good = 2,
        Bad = 3,
        VeryBad = 4
    }
}