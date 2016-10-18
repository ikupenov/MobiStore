using Mongo.Data;
using Mongo.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mongo.Client
{
    public class Program
    {
        private const string ServerName = "mongodb://localhost";
        private const string DatabaseName = "MobiStore";

        public static void Main(string[] args)
        {
            IMongoDatabase db = MongoDatabase.GetDatabase(ServerName, DatabaseName);

            var phones = db.GetCollection<MobileDevice>("mobileDevices");

            for (int i = 0; i < 100; ++i)
            {
                MobileDevice phone = new MobileDevice
                {
                    Battery = new Battery { Capacity = 4 },
                    Model = "dsadas"
                };

                phones.InsertOne(phone);
            }

            var found = phones.Find(new BsonDocument()).ToList();
            System.Console.WriteLine();
        }
    }
}