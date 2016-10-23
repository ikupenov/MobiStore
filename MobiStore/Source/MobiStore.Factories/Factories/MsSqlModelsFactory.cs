using System.Linq;

using MobiStore.Data.Contracts;
using MobiStore.Factories.Contracts;
using MobiStore.Models.Common;
using MobiStore.Models.Enumerations;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;

namespace MobiStore.Factories.Factories
{
    public class MsSqlModelsFactory : ModelsFactory, IModelsFactory
    {
        private readonly ISqlServerDb db;

        public MsSqlModelsFactory(ISqlServerDb db)
        {
            this.db = db;
        }

        public override Battery CreateBattery(BatteryType type, int capacity, Country country = null)
        {
            var battery = base.CreateBattery(type, capacity, country);

            if (country != null)
            {
                country = this.GetCountry(country.Name);
                battery.Country = country;
                battery.CountryId = country.Id;
            }

            return battery;
        }

        public override Display CreateDisplay(DisplayType type, double size, string resolution, Country country = null)
        {
            var display = base.CreateDisplay(type, size, resolution, country);

            if (country != null)
            {
                country = this.GetCountry(country.Name);
                display.Country = country;
                display.CountryId = country.Id;
            }

            return display;
        }

        public override Processor CreateProcessor(double clockSpeed, double cacheMemory, Country country = null)
        {
            var processor = base.CreateProcessor(clockSpeed, cacheMemory, country);

            if (country != null)
            {
                country = this.GetCountry(country.Name);
                processor.Country = country;
                processor.CountryId = country.Id;
            }

            return processor;
        }

        public override MobileDevice CreateMobileDevice(Brand brand, string model, Display display = null, Battery battery = null, Processor processor = null, Country country = null)
        {
            var mobileDevice = base.CreateMobileDevice(brand, model, display, battery, processor, country);

            if (display != null)
            {
                var foundDisplay = this.GetDisplay(display);
                mobileDevice.Display = foundDisplay;
                mobileDevice.DisplayId = foundDisplay.Id;
            }

            if (battery != null)
            {
                var foundBattery = this.GetBattery(battery);
                mobileDevice.Battery = foundBattery;
                mobileDevice.BatteryId = foundBattery.Id;
            }

            if (processor != null)
            {
                var foundProcessor = this.GetProcessor(processor);
                mobileDevice.Processor = foundProcessor;
                mobileDevice.ProcessorId = foundProcessor.Id;
            }

            if (country != null)
            {
                var foundCountry = this.GetCountry(country.Name);
                mobileDevice.Country = foundCountry;
                mobileDevice.CountryId = foundCountry.Id;
            }

            return mobileDevice;
        }

        private Battery GetBattery(Battery battery)
        {
            var foundBattery = this.db
                .Batteries
                .All()
                .FirstOrDefault(b => b == battery);

            if (foundBattery == null)
            {
                foundBattery = new Battery { Capacity = battery.Capacity, Type = battery.Type };

                if (battery.Country != null)
                {
                    var foundCountry = this.GetCountry(battery.Country.Name);
                    foundBattery.Country = foundCountry;
                    foundBattery.CountryId = foundCountry.Id;
                }
            }

            return foundBattery;
        }

        private Display GetDisplay(Display display)
        {
            var foundDisplay = this.db
                .Displays
                .All()
                .FirstOrDefault(d => d == display);

            if (foundDisplay == null)
            {
                foundDisplay = new Display { Resolution = display.Resolution, Size = display.Size, Type = display.Type };

                if (display.Country != null)
                {
                    var foundCountry = this.GetCountry(display.Country.Name);
                    foundDisplay.Country = foundCountry;
                    foundDisplay.CountryId = foundCountry.Id;
                }
            }

            return foundDisplay;
        }

        private Processor GetProcessor(Processor processor)
        {
            var foundProcessor = this.db
                .Processors
                .All()
                .FirstOrDefault(p => p == processor);

            if (foundProcessor == null)
            {
                foundProcessor = new Processor { CacheMemory = processor.CacheMemory, ClockSpeed = processor.ClockSpeed };

                if (processor.Country != null)
                {
                    var foundCountry = this.GetCountry(processor.Country.Name);
                    foundProcessor.Country = foundCountry;
                    foundProcessor.CountryId = foundCountry.Id;
                }
            }

            return foundProcessor;
        }

        private Country GetCountry(string countryName)
        {
            var country = this.db
                .Countries
                .All()
                .FirstOrDefault(c => c.Name == countryName);

            if (country == null)
            {
                country = new Country { Name = countryName };
                this.db.Countries.Add(country);
            }

            return country;
        }
    }
}