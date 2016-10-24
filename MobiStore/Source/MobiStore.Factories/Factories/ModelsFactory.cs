using System;

using MobiStore.Factories.Contracts;
using MobiStore.Models.Common;
using MobiStore.Models.Enumerations;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;

namespace MobiStore.Factories
{
    public abstract class ModelsFactory : IModelsFactory
    {
        private const string NullOrEmptyString = "{0} cannot be null or empty.";
        private const string NonPositiveNumber = "{0} must be a positive number.";

        public virtual Country CreateCountry(string name)
        {
            string nullOrEmptyNameMessage = string.Format(NullOrEmptyString, "Country's name");
            this.ValidateIfStringIsNullOrEmpty(name, nullOrEmptyNameMessage);

            var country = new Country { Name = name };
            return country;
        }

        public virtual Battery CreateBattery(BatteryType type, int capacity, Country country = null)
        {
            string invalidCapacityMessage = string.Format(NonPositiveNumber, "Battery's capacity");
            this.ValidateIfNumberIsPositive(capacity, invalidCapacityMessage);

            var battery = new Battery { Type = type, Capacity = capacity };
            return battery;
        }

        public virtual Display CreateDisplay(DisplayType type, double size, string resolution, Country country = null)
        {
            string invalidSizeMessage = string.Format(NonPositiveNumber, "Display's size");
            string nullOrEmptyResolution = string.Format(NullOrEmptyString, "Display's resolution");
            this.ValidateIfNumberIsPositive((decimal)size, invalidSizeMessage);
            this.ValidateIfStringIsNullOrEmpty(resolution, nullOrEmptyResolution);

            var display = new Display { Type = type, Size = size, Resolution = resolution };
            return display;
        }

        public virtual Processor CreateProcessor(double clockSpeed, double cacheMemory, Country country = null)
        {
            string invalidClockSpeedMessage = string.Format(NonPositiveNumber, "Processor's clock speed");
            string invalidCacheMemoryMessage = string.Format(NonPositiveNumber, "Processor's cache memory");
            this.ValidateIfNumberIsPositive((decimal)clockSpeed, invalidClockSpeedMessage);
            this.ValidateIfNumberIsPositive((decimal)cacheMemory, invalidCacheMemoryMessage);

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
            string nullOrEmptyModelMessage = string.Format(NullOrEmptyString, "Mobile device's model");
            this.ValidateIfStringIsNullOrEmpty(model, nullOrEmptyModelMessage);

            var mobileDevice = new MobileDevice { Brand = brand, Model = model };
            return mobileDevice;
        }

        private void ValidateIfStringIsNullOrEmpty(string value, string errorMessage)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(errorMessage);
            }
        }

        private void ValidateIfNumberIsPositive(decimal value, string errorMessage)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(errorMessage);
            }
        }
    }
}