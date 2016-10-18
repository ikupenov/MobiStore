using Mongo.Models.Enumerations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Models
{
    public class MobileDevice
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Model { get; set; }

        public Brand Brand { get; set; }

        public Battery Battery { get; set; }

        public Display Display { get; set; }

        public Processor Processor { get; set; }

        public int RAM { get; set; }
    }
}