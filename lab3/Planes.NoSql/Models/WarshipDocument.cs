using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Warships.Nosql.Models
{
    public class WarshipDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("type")]
        public string Type { get; set; } = string.Empty;

        [BsonElement("captain")]
        public string Captain { get; set; } = string.Empty;

        [BsonElement("crewMembers")]
        public List<string> CrewMembers { get; set; } = new();
    }
}
