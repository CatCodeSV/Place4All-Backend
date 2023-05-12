using Place4AllBackend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Place4AllBackend.Domain.Entities
{
    public class RestaurantsFeatures : AuditableEntity
    {
        public int RestaurantsId { get; set; }
        public int FeaturesId { get; set; }
        public Restaurant Restaurant { get; set; }
        public Feature Feature { get; set; }
    }
}
