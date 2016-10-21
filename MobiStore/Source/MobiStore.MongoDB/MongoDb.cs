using System.Linq;

using MobiStore.Data.Contracts;
using MobiStore.Models.Common;
using MobiStore.Models.Contracts;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;

using MongoDB.Driver;

namespace MobiStore.MongoDB
{
    public class MongoDb
    {
        private static IMongoDatabase instance;

        public static IMongoDatabase GetInstance(string serverName, string databaseName)
        {
            if (instance == null)
            {
                var client = new MongoClient(serverName);
                instance = client.GetDatabase(databaseName);
            }

            return instance;
        }

        public void TransferToSqlServer(IMongoDatabase mongoDataBase, IMobiStoreData sqlServerDatabase)
        {
            this.TransferDisplays(mongoDataBase, sqlServerDatabase);
            this.TransferCountries(mongoDataBase, sqlServerDatabase);
            this.TransferBatteries(mongoDataBase, sqlServerDatabase);
            this.TransferProcessors(mongoDataBase, sqlServerDatabase);
            this.TransferMobileDevices(mongoDataBase, sqlServerDatabase);
        }

        private void TransferDisplays(IMongoDatabase mongoDatabse, IMobiStoreData sqlServerDatabase)
        {
            var displaysCollection = mongoDatabse.GetCollection<Display>("displays");
            var mongoDisplays = displaysCollection.Find(d => true).ToList();
            var displaysTable = sqlServerDatabase.Displays;

            foreach (var display in mongoDisplays)
            {
                var newDisplay = new Display
                {
                    Country = display.Country == null ? null : this.GetCountry(sqlServerDatabase, display),
                    Resolution = display.Resolution,
                    Size = display.Size,
                    Type = display.Type
                };
                displaysTable.Add(newDisplay);
            }

            sqlServerDatabase.SaveChanges();
        }

        private void TransferBatteries(IMongoDatabase mongoDatabse, IMobiStoreData sqlServerDatabase)
        {
            var batteriesCollection = mongoDatabse.GetCollection<Battery>("batteries");
            var mongoBatteries = batteriesCollection.Find(b => true).ToList();
            var batteriesTable = sqlServerDatabase.Batteries;

            foreach (var battery in mongoBatteries)
            {
                var newBattery = new Battery
                {
                    Capacity = battery.Capacity,
                    Type = battery.Type,
                    Country = battery.Country == null ? null : this.GetCountry(sqlServerDatabase, battery)
                };

                batteriesTable.Add(newBattery);
            }

            sqlServerDatabase.SaveChanges();
        }

        private void TransferProcessors(IMongoDatabase mongoDatabse, IMobiStoreData sqlServerDatabase)
        {
            var processorsCollection = mongoDatabse.GetCollection<Processor>("processors");
            var mongoProcessors = processorsCollection.Find(b => true).ToList();
            var processorsTable = sqlServerDatabase.Processors;

            foreach (var processor in mongoProcessors)
            {
                var newProcessor = new Processor
                {
                    CacheMemory = processor.CacheMemory,
                    ClockSpeed = processor.ClockSpeed,
                    Country = processor.Country == null ? null : this.GetCountry(sqlServerDatabase, processor),
                };

                processorsTable.Add(newProcessor);
            }

            sqlServerDatabase.SaveChanges();
        }

        private void TransferCountries(IMongoDatabase mongoDatabse, IMobiStoreData sqlServerDatabase)
        {
            var countriesCollection = mongoDatabse.GetCollection<Country>("countries");
            var mongoCountries = countriesCollection.Find(b => true).ToList();
            var countriesTable = sqlServerDatabase.Countries;

            foreach (var country in mongoCountries)
            {
                var newCountry = new Country 
                {
                    Name = country.Name
                };

                countriesTable.Add(newCountry);
            }

            sqlServerDatabase.SaveChanges();
        }

        private void TransferMobileDevices(IMongoDatabase mongoDatabse, IMobiStoreData sqlServerDatabase)
        {
            var devicesCollection = mongoDatabse.GetCollection<MobileDevice>("mobileDevices");
            var mongoDevices = devicesCollection.Find(b => true).ToList();
            var devicesTable = sqlServerDatabase.MobileDevices;

            foreach (var device in mongoDevices)
            {
                var battery = sqlServerDatabase
                    .Batteries
                    .All()
                    .FirstOrDefault(b =>
                        b.Country == device.Battery.Country &&
                        b.Capacity == device.Battery.Capacity &&
                        b.Type == device.Battery.Type);

                var display = sqlServerDatabase
                    .Displays
                    .All()
                    .FirstOrDefault(d =>
                        d.Resolution == device.Display.Resolution &&
                        d.Size == device.Display.Size &&
                        d.Type == device.Display.Type);

                var processor = sqlServerDatabase.Processors
                    .All()
                    .FirstOrDefault(p =>
                        p.Country == device.Processor.Country &&
                        p.ClockSpeed == device.Processor.ClockSpeed &&
                        p.CacheMemory == device.Processor.CacheMemory);

                var country = sqlServerDatabase.Countries
                    .All()
                    .FirstOrDefault(c => c.Name == device.Country.Name);

                var newDevice = new MobileDevice 
                {
                    Battery = battery,
                    BatteryId = battery.Id,
                    Display = display,
                    DisplayId = display.Id,
                    Country = country,
                    CountryId = country.Id,
                    Processor = processor,
                    ProcessorId = processor.Id,
                    Brand = device.Brand,
                    Model = device.Model,
                };

                devicesTable.Add(newDevice);
            }

            sqlServerDatabase.SaveChanges();
        }

        private Country GetCountry(IMobiStoreData sqlServerDatabase, ICountryManufacturer mongoObject)
        {
            var country = sqlServerDatabase
                .Countries
                .All()
                .FirstOrDefault(c => c.Name == mongoObject.Country.Name);

            if (country == null)
            {
                country = new Country { Name = mongoObject.Country.Name };
                sqlServerDatabase.Countries.Add(country);
                sqlServerDatabase.SaveChanges();
            }

            return country;
        }
    }
}