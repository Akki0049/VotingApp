using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Voting.API.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CandidateName { get; set; }
        public string Party { get; set; }
        public string City { get; set; }
        public string PartyImage { get; set; }
        public decimal WardNo { get; set; }
    }
}