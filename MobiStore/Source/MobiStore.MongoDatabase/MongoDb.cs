using System.Linq;

using MobiStore.Data.Contracts;
using MobiStore.Factories.Contracts;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;

using MongoDB.Driver;

namespace MobiStore.MongoDatabase
{
    public class MongoDb
    {
        private static IMongoDatabase instance;

        private readonly IModelsFactory mssqlModelsFactory;

        public MongoDb(IModelsFactory mssqlModelsFactory)
        {
            this.mssqlModelsFactory = mssqlModelsFactory;
        }

        public static IMongoDatabase GetInstance(string serverName, string databaseName)
        {
            if (instance == null)
            {
                var client = new MongoClient(serverName);
                instance = client.GetDatabase(databaseName);
            }

            return instance;
        }

        public void TransferToSqlServer(IMongoDatabase mongoDataBase, ISqlServerDb sqlServerDatabase)
        {
            this.TransferDisplays(mongoDataBase, sqlServerDatabase);
            this.TransferBatteries(mongoDataBase, sqlServerDatabase);
            this.TransferProcessors(mongoDataBase, sqlServerDatabase);
            this.TransferMobileDevices(mongoDataBase, sqlServerDatabase);
        }

        private void TransferDisplays(IMongoDatabase mongoDatabse, ISqlServerDb sqlServerDatabase)
        {
            var displaysCollection = mongoDatabse.GetCollection<Display>("displays");
            var mongoDisplays = displaysCollection.Find(d => true).ToList();
            var displaysTable = sqlServerDatabase.Displays;

            foreach (var display in mongoDisplays)
            {
                var newDisplay = this.mssqlModelsFactory
                    .CreateDisplay(display.Type, display.Size, display.Resolution);
                displaysTable.Add(newDisplay);
            }

            sqlServerDatabase.SaveChanges();
        }

        private void TransferBatteries(IMongoDatabase mongoDatabse, ISqlServerDb sqlServerDatabase)
        {
            var batteriesCollection = mongoDatabse.GetCollection<Battery>("batteries");
            var mongoBatteries = batteriesCollection.Find(b => true).ToList();
            var batteriesTable = sqlServerDatabase.Batteries;

            foreach (var battery in mongoBatteries)
            {
                var newBattery = this.mssqlModelsFactory
                    .CreateBattery(battery.Type, battery.Capacity);
                batteriesTable.Add(newBattery);
            }

            sqlServerDatabase.SaveChanges();
        }

        private void TransferProcessors(IMongoDatabase mongoDatabse, ISqlServerDb sqlServerDatabase)
        {
            var processorsCollection = mongoDatabse.GetCollection<Processor>("processors");
            var mongoProcessors = processorsCollection.Find(b => true).ToList();
            var processorsTable = sqlServerDatabase.Processors;

            foreach (var processor in mongoProcessors)
            {
                var newProcessor = this.mssqlModelsFactory
                    .CreateProcessor(processor.ClockSpeed, processor.CacheMemory);
                processorsTable.Add(newProcessor);
            }

            sqlServerDatabase.SaveChanges();
        }

        private void TransferMobileDevices(IMongoDatabase mongoDatabse, ISqlServerDb sqlServerDatabase)
        {
            var devicesCollection = mongoDatabse.GetCollection<MobileDevice>("mobileDevices");
            var mongoDevices = devicesCollection.Find(b => true).ToList();
            var devicesTable = sqlServerDatabase.MobileDevices;

            foreach (var device in mongoDevices)
            {
                var newDevice = this.mssqlModelsFactory
                    .CreateMobileDevice(
                    device.Brand,
                    device.Model,
                    device.Display,
                    device.Battery,
                    device.Processor);

                devicesTable.Add(newDevice);
            }

            sqlServerDatabase.SaveChanges();
        }      
    }
}