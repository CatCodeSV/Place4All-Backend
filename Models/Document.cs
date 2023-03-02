using MongoDB.Bson;

namespace WebApi.Models
{
    public class Document: IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
