using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cardano_Catalyst.Models
{
    public class CustomFields
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Version { get; set; }
    }
}
