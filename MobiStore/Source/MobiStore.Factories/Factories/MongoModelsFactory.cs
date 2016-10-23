using MobiStore.Factories.Contracts;
using MobiStore.Models.Common;
using MobiStore.Models.Enumerations;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;

namespace MobiStore.Factories.Factories
{
    public class MongoModelsFactory : ModelsFactory, IModelsFactory
    {
        public override Battery CreateBattery(BatteryType type, int capacity, Country country = null)
        {
            var battery = base.CreateBattery(type, capacity, country);
            battery.Country = country;

            return battery;
        }

        public override Display CreateDisplay(DisplayType type, double size, string resolution, Country country = null)
        {
            var display = base.CreateDisplay(type, size, resolution, country);
            display.Country = country;

            return display;
        }

        public override Processor CreateProcessor(double clockSpeed, double cacheMemory, Country country = null)
        {
            var processor = base.CreateProcessor(clockSpeed, cacheMemory, country);
            processor.Country = country;

            return processor;
        }

        public override MobileDevice CreateMobileDevice(Brand brand, string model, Display display = null, Battery battery = null, Processor processor = null, Country country = null)
        {
            var device = base.CreateMobileDevice(brand, model, display, battery, processor, country);
            device.Display = display;
            device.Battery = battery;
            device.Country = country;
            device.Processor = processor;

            return device;
        }
    }
}