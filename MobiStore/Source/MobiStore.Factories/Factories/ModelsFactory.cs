using MobiStore.Factories.Contracts;
using MobiStore.Models.Common;
using MobiStore.Models.Enumerations;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;

namespace MobiStore.Factories
{
    public abstract class ModelsFactory : IModelsFactory
    {
        public virtual Country CreateCountry(string name)
        {
            var country = new Country { Name = name };
            return country;
        }

        public virtual Battery CreateBattery(BatteryType type, int capacity, Country country = null)
        {
            var battery = new Battery { Type = type, Capacity = capacity };
            return battery;
        }

        public virtual Display CreateDisplay(DisplayType type, double size, string resolution, Country country = null)
        {
            var display = new Display { Type = type, Size = size, Resolution = resolution };
            return display;
        }

        public virtual Processor CreateProcessor(double clockSpeed, double cacheMemory, Country country = null)
        {
            var processor = new Processor { ClockSpeed = clockSpeed, CacheMemory = cacheMemory };
            return processor;
        }

        public virtual MobileDevice CreateMobileDevice(
            Brand brand,
            string model,
            Display display = null,
            Battery battery = null,
            Processor processor = null,
            Country country = null)
        {
            var mobileDevice = new MobileDevice { Brand = brand, Model = model };
            return mobileDevice;
        }
    }
}