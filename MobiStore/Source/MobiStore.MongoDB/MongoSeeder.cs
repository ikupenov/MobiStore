using MobiStore.Models.Common;
using MobiStore.Models.Enumerations;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;
using MongoDB.Bson;

namespace MobiStore.MongoDB
{
    public class MongoSeeder
    {
        public void SeedDatabase(string serverName, string databaseName)
        {
            var database = MongoDb.GetInstance(serverName, databaseName);

            var countries = database.GetCollection<Country>("countries");
            if (countries.Count(new BsonDocument()) == 0)
            {
                var firstBattery = ModelsFactory.CreateBattery(BatteryType.AAMI, 20);
                var secondBattery = ModelsFactory.CreateBattery(BatteryType.G3, 30);
                var thirdBattery = ModelsFactory.CreateBattery(BatteryType.LiIon, 40);

                var firstDisplay = ModelsFactory.CreateDisplay("400x600", 3.4, DisplayType.LED);
                var secondDisplay = ModelsFactory.CreateDisplay("600x600", 4.4, DisplayType.Retina);
                var thirdDisplay = ModelsFactory.CreateDisplay("900x600", 5.4, DisplayType.AMO);

                var firstProcessor = ModelsFactory.CreateProcessor(3.4, 12);
                var secondProcessor = ModelsFactory.CreateProcessor(2.4, 8);
                var thirdProcessor = ModelsFactory.CreateProcessor(1.4, 5);

                var firstCountry = ModelsFactory.CreateCountry("Bulgaria");
                var secondCountry = ModelsFactory.CreateCountry("England");
                var thirdCountry = ModelsFactory.CreateCountry("Russia");

                var firstDevice = ModelsFactory.CreateMobileDevice(
                    "IPhone",
                    Brand.Apple,
                    firstCountry,
                    firstBattery,
                    firstDisplay,
                    firstProcessor);
                var secondDevice = ModelsFactory.CreateMobileDevice(
                    "Galaxy",
                    Brand.Samsung,
                    secondCountry,
                    secondBattery,
                    secondDisplay,
                    secondProcessor);
                var thirdDevice = ModelsFactory.CreateMobileDevice(
                    "Desire",
                    Brand.HTC,
                    thirdCountry,
                    thirdBattery,
                    thirdDisplay,
                    thirdProcessor);

                var devicesCollection = database.GetCollection<MobileDevice>("mobileDevices");
                var batteriesCollection = database.GetCollection<Battery>("batteries");
                var displaysCollection = database.GetCollection<Display>("displays");
                var processorsCollection = database.GetCollection<Processor>("processors");
                var countriesCollection = database.GetCollection<Country>("countries");

                devicesCollection.InsertMany(new[] { firstDevice, secondDevice, thirdDevice });
                batteriesCollection.InsertMany(new[] { firstBattery, secondBattery, thirdBattery });
                displaysCollection.InsertMany(new[] { firstDisplay, secondDisplay, thirdDisplay });
                processorsCollection.InsertMany(new[] { firstProcessor, secondProcessor, thirdProcessor });
                countries.InsertMany(new[] { firstCountry, secondCountry, thirdCountry });
            }
        }
    }
}