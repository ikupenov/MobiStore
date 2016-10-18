using Mongo.Models;
using MongoDB.Driver;

namespace Mongo.Data
{
    public static class MongoDatabase
    {
        private const string ServerName = "mongodb://localhost";
        private const string DatabaseName = "MobiStore";

        public static IMongoDatabase InitializeDocuments()
        {
            MongoClient client = new MongoClient(ServerName);
            IMongoDatabase database = client.GetDatabase(DatabaseName);

            database.GetCollection<Display>("displays");
            database.GetCollection<Battery>("batteries");
            database.GetCollection<MobileDevice>("mobileDevices");
            database.GetCollection<Processor>("processors");

            return database;
        }
    }
}