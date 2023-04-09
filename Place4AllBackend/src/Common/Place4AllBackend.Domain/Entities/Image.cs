using Place4AllBackend.Domain.Common;

namespace Place4AllBackend.Domain.Entities
{
    public class Image : AuditableEntity
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }
    }
}