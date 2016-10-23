using MongoDB.Driver;

namespace MobiStore.Data
{
    public static class MongoDbProvider
    {
        public static IMongoDatabase GetDatabase(string serverName, string databaseName)
        {
            IMongoClient client = new MongoClient(serverName);
            IMongoDatabase database = client.GetDatabase(databaseName);

            return database;
        }
    }
}
