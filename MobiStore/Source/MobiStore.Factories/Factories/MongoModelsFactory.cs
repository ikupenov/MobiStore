using MobiStore.Factories.Contracts;
using MobiStore.Models.Enumerations;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;

namespace MobiStore.Factories.Factories
{
    public class MongoModelsFactory : ModelsFactory, IModelsFactory
    {
        public override Battery CreateBattery(BatteryType type, int capacity)
        {
            var battery = base.CreateBattery(type, capacity);
            return battery;
        }

        public override Display CreateDisplay(DisplayType type, double size, string resolution)
        {
            var display = base.CreateDisplay(type, size, resolution);
            return display;
        }

        public override Processor CreateProcessor(double clockSpeed, double cacheMemory)
        {
            var processor = base.CreateProcessor(clockSpeed, cacheMemory);
            return processor;
        }

        public override MobileDevice CreateMobileDevice(Brand brand, string model, Display display = null, Battery battery = null, Processor processor = null)
        {
            var device = base.CreateMobileDevice(brand, model, display, battery, processor);
            device.Display = display;
            device.Battery = battery;
            device.Processor = processor;

            return device;
        }
    }
}