﻿using MobiStore.Models.Common;
using MobiStore.Models.Enumerations;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;

namespace MobiStore.Factories.Contracts
{
    public interface IModelsFactory
    {
        Country CreateCountry(string name);

        Battery CreateBattery(BatteryType type, int capacity, Country country = null);

        Display CreateDisplay(DisplayType type, double size, string resolution, Country country = null);

        Processor CreateProcessor(double clockSpeed, double cacheMemory, Country country = null);

        MobileDevice CreateMobileDevice(
            Brand brand,
            string model,
            Display display = null,
            Battery battery = null,
            Processor processor = null,
            Country country = null);
    }
}