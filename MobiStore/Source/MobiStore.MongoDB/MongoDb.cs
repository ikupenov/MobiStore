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
                Display display = this.GetDisplay(device, sqlServerDatabase);
                Battery battery = this.GetBattery(device, sqlServerDatabase);
                Processor processor = this.GetProcessor(device, sqlServerDatabase);
                Country country = null;
                
                if (device.Country != null)
                {
                    country = new Country { Name = device.Country.Name };
                    sqlServerDatabase.Countries.Add(country);
                    sqlServerDatabase.SaveChanges();
                }

                var newDevice = new MobileDevice
                {
                    Brand = device.Brand,
                    Model = device.Model,
                };

                if (display != null)
                {
                    newDevice.Display = display;
                    newDevice.DisplayId = display.Id;
                }

                if (battery != null)
                {
                    newDevice.Battery = battery;
                    newDevice.BatteryId = battery.Id;
                }

                if (processor != null)
                {
                    newDevice.Processor = processor;
                    newDevice.ProcessorId = processor.Id;
                }

                if (country != null)
                {
                    newDevice.Country = country;
                    newDevice.CountryId = country.Id;
                }

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

        private Display GetDisplay(MobileDevice device, IMobiStoreData sqlServerDatabase)
        {
            Display display = null;
            if (device.Display != null)
            {
                display = new Display
                {
                    Country = device.Display.Country,
                    Resolution = device.Display.Resolution,
                    Size = device.Display.Size,
                    Type = device.Display.Type
                };

                sqlServerDatabase.Displays.Add(display);
                sqlServerDatabase.SaveChanges();
            }

            return display;
        }

        private Battery GetBattery(MobileDevice device, IMobiStoreData sqlServerDatabase)
        {
            Battery battery = null;
            if (device.Battery != null)
            {
                battery = new Battery
                {
                    Capacity = device.Battery.Capacity,
                    Country = device.Battery.Country,
                    Type = device.Battery.Type
                };

                sqlServerDatabase.Batteries.Add(battery);
                sqlServerDatabase.SaveChanges();
            }

            return battery;
        }

        private Processor GetProcessor(MobileDevice device, IMobiStoreData sqlServerDatabase)
        {
            Processor processor = null;
            if (device.Processor != null)
            {
                processor = new Processor
                {
                    CacheMemory = device.Processor.CacheMemory,
                    ClockSpeed = device.Processor.ClockSpeed,
                    Country = device.Processor.Country
                };

                sqlServerDatabase.Processors.Add(processor);
                sqlServerDatabase.SaveChanges();
            }

            return processor;
        }
    }
}