using System.Collections.Generic;

using MobiStore.Factories.Contracts;
using MobiStore.Models.Enumerations;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;

using MongoDB.Bson;

namespace MobiStore.MongoDatabase
{
    public class MongoSeeder
    {
        private const int NumberOfDevicesToSeed = 3;

        private readonly IModelsFactory modelsFactory;

        public MongoSeeder(IModelsFactory modelsFactory)
        {
            this.modelsFactory = modelsFactory;
        }

        public void SeedDatabase(string serverName, string databaseName)
        {
            var database = MongoDb.GetInstance(serverName, databaseName);
            var batteriesCollection = database.GetCollection<Battery>("batteries");
            long batteriesCount = batteriesCollection.Count(new BsonDocument());

            if (batteriesCount == 0)
            {
                var batteries = this.GetBatteries();
                var displays = this.GetDisplays();
                var processors = this.GetProcessors();
                var brands = new[] { Brand.Apple, Brand.HTC, Brand.Samsung };
                var models = new[] { "IPhone", "Desire", "Galaxy" };
                var devices = this.GetDevices(batteries, displays, processors, brands, models);
                
                database.GetCollection<MobileDevice>("mobileDevices").InsertMany(devices);
                database.GetCollection<Battery>("batteries").InsertMany(batteries);
                database.GetCollection<Display>("displays").InsertMany(displays);
                database.GetCollection<Processor>("processors").InsertMany(processors);
            }
        }

        private IList<Battery> GetBatteries()
        {
            var firstBattery = this.modelsFactory.CreateBattery(BatteryType.AAMI, 20);
            var secondBattery = this.modelsFactory.CreateBattery(BatteryType.G3, 30);
            var thirdBattery = this.modelsFactory.CreateBattery(BatteryType.LiIon, 40);
            var batteries = new[] { firstBattery, secondBattery, thirdBattery };

            return batteries;
        }

        private IList<Display> GetDisplays()
        {
            var firstDisplay = this.modelsFactory.CreateDisplay(DisplayType.LED, 3.4, "400x600");
            var secondDisplay = this.modelsFactory.CreateDisplay(DisplayType.Retina, 4.4, "600x600");
            var thirdDisplay = this.modelsFactory.CreateDisplay(DisplayType.AMO, 5.4, "900x600");
            var displays = new[] { firstDisplay, secondDisplay, thirdDisplay };

            return displays;
        }

        private IList<Processor> GetProcessors()
        {
            var firstProcessor = this.modelsFactory.CreateProcessor(3.4, 12);
            var secondProcessor = this.modelsFactory.CreateProcessor(2.4, 8);
            var thirdProcessor = this.modelsFactory.CreateProcessor(1.4, 5);
            var processors = new[] { firstProcessor, secondProcessor, thirdProcessor };

            return processors;
        }

        private IEnumerable<MobileDevice> GetDevices(
            IList<Battery> batteries,
            IList<Display> displays,
            IList<Processor> processors,
            IList<Brand> brands,
            IList<string> models)
        {
            var devices = new List<MobileDevice>();

            for (int i = 0; i < NumberOfDevicesToSeed; i++)
            {
                var currentDevice = this.modelsFactory.CreateMobileDevice(
                    brands[0],
                    models[0],
                    displays[0],
                    batteries[0],
                    processors[0]);

                devices.Add(currentDevice);
            }

            return devices;
        } 
    }
}