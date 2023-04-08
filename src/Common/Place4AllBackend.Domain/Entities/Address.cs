using Place4AllBackend.Domain.Common;

namespace Place4AllBackend.Domain.Entities
{
    public class Address : AuditableEntity
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Province { get; set; }
    }
}