using Mongo.Data;
using Mongo.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mongo.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            IMongoDatabase db = MongoDatabase.InitializeDocuments();

            MobileDevice phone = new MobileDevice
            {
                Battery = new Battery { Capacity = 4 },
                Model = "dsadas"
            };

            var phones = db.GetCollection<MobileDevice>("mobileDevices");
            phones.InsertOne(phone);

            var found = phones.Find(new BsonDocument()).ToList();
            System.Console.WriteLine();
        }
    }
}