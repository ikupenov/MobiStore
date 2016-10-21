using MongoDB.Driver;

namespace MobiStore.MongoDB
{
    public static class MongoDb
    {
        public static IMongoDatabase GetInstance(string serverName, string databaseName)
        {
            var client = new MongoClient(serverName);
            var database = client.GetDatabase(databaseName);
            return database;
        }
    }
}