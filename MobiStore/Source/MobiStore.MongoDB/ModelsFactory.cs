using MobiStore.Models;
using MobiStore.Models.Common;
using MobiStore.Models.Enumerations;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;

namespace MobiStore.MongoDB
{
    public static class ModelsFactory
    {
        public static Country CreateCountry(string name)
        {
            var country = new Country { Name = name };
            return country;
        }

        public static Employee CreateEmployee(string name)
        {
            var employee = new Employee { Name = name };
            return employee;
        }

        public static Battery CreateBattery(BatteryType type, int capacity, Country country = null)
        {
            var battery = new Battery { Type = type, Capacity = capacity, Country = country };
            return battery;
        }

        public static Display CreateDisplay(string resolution, double size, DisplayType type, Country country = null)
        {
            var display = new Display
            {
                Resolution = resolution,
                Size = size,
                Type = type,
                Country = country
            };

            return display;
        }

        public static Processor CreateProcessor(double clockSpeed, double cacheMemory, Country country = null)
        {
            var processor = new Processor
            {
                ClockSpeed = clockSpeed,
                CacheMemory = cacheMemory,
                Country = country
            };
            return processor;
        }

        public static MobileDevice CreateMobileDevice(
            string model,
            Brand brand,
            Country country = null,
            Battery battery = null,
            Display display = null,
            Processor processor = null)
        {
            var device = new MobileDevice
            {
                Model = model,
                Brand = brand,
                Country = country,
                Battery = battery,
                Display = display,
                Processor = processor
            };

            return device;
        }
    }
}