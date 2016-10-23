using MobiStore.Models.Common;
using MobiStore.Models.Enumerations;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;

namespace MobiStore.Utils.Factories
{
    public  class MobileDeviceFactory
    {
        public Battery CreateBattery(BatteryType batteryType, int batteryCapacity, Country country = null)
        {
            var battery = new Battery
            {
                Type = batteryType,
                Capacity = batteryCapacity
            };

            if (country != null)
            {
                battery.Country = country;
                battery.CountryId = country.Id;
            }

            return battery;
        }

        public Display CreateDisplay(
            DisplayType displayType,
            double displaySize,
            string displayResolution = null,
            Country country = null)
        {
            var display = new Display()
            {
                Type = displayType,
                Size = displaySize,
                Resolution = displayResolution
            };

            if (country != null)
            {
                display.Country = country;
                display.CountryId = country.Id;
            }

            return display;
        }

        public Processor CreateProcessor(double cacheMemory, double clockSpeed, Country country = null)
        {
            var processor = new Processor()
            {
                CacheMemory = cacheMemory,
                ClockSpeed = clockSpeed
            };

            if (country != null)
            {
                processor.Country = country;
                processor.CountryId = country.Id;
            }

            return processor;
        }

        public MobileDevice CreateMobileDevice(
            Brand brand,
            string model,
            Battery battery = null,
            Display display = null,
            Processor processor = null,
            Country country = null)
        {
            var mobileDevice = new MobileDevice()
            {
                Brand = brand,
                Model = model
            };

            if (battery != null)
            {
                mobileDevice.Battery = battery;
                mobileDevice.BatteryId = battery.Id;
            }

            if (display != null)
            {
                mobileDevice.Display = display;
                mobileDevice.DisplayId = display.Id;
            }

            if (processor != null)
            {
                mobileDevice.Processor = processor;
                mobileDevice.ProcessorId = processor.Id;
            }

            if (country != null)
            {
                mobileDevice.Country = country;
                mobileDevice.CountryId = country.Id;
            }

            return mobileDevice;
        }
    }
}