﻿using MobiStore.Models.Enumerations;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;

namespace MobiStore.Utils.Factories
{
    internal class MobileDeviceFactory
    {
        internal Battery CreateBattery(BatteryType batteryType, int batteryCapacity)
        {
            var battery = new Battery
            {
                Type = batteryType,
                Capacity = batteryCapacity
            };

            return battery;
        }

        internal Display CreateDisplay(
            DisplayType displayType,
            double displaySize,
            string displayResolution)
        {
            var display = new Display()
            {
                Type = displayType,
                Size = displaySize,
                Resolution = displayResolution
            };

            return display;
        }

        internal Processor CreateProcessor(double cacheMemory, double clockSpeed)
        {
            var processor = new Processor()
            {
                CacheMemory = cacheMemory,
                ClockSpeed = clockSpeed
            };

            return processor;
        }

        internal MobileDevice CreateMobileDevice(
            Brand brand,
            string model,
            Battery battery,
            Display display,
            Processor processor)
        {
            var mobileDevice = new MobileDevice()
            {
                Brand = brand,
                Model = model,
                Battery = battery,
                Display = display,
                Processor = processor
            };

            return mobileDevice;
        }
    }
}