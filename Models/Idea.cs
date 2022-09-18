using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cardano_Catalyst.Models
{
    public class Idea
    {
        public string? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Campaign { get; set; }
        public string Stage { get; set; }
        public string[] Tags { get; set; }
        public CustomField[] CustomFields { get; set; }
        public string[] Contributors { get; set; }
        public BsonTimestamp SubmittedAt { get; set; }
        public int Version { get; set; }
    }
}
