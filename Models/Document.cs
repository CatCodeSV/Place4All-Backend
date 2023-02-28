using MongoDB.Bson;

namespace WebApi.Models
{
    public class Document
    {
        public string? Id { get; set; }

        public DateTime CreatedAt => DateTime.Now;
    }
}
