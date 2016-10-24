using System.Linq;

using MobiStore.Data.Contracts;
using MobiStore.Models.Enumerations;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;

namespace MobiStore.Factories.Factories
{
    public class MsSqlModelsFactory : ModelsFactory
    {
        private readonly ISqlServerDb db;

        public MsSqlModelsFactory(ISqlServerDb db)
        {
            this.db = db;
        }

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
            var mobileDevice = base.CreateMobileDevice(brand, model, display, battery, processor);

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

            return mobileDevice;
        }

        private Battery GetBattery(Battery battery)
        {
            var foundBattery = this.db
                .Batteries
                .All()
                .FirstOrDefault(
                    b => b.Capacity == battery.Capacity &&
                    b.Type == battery.Type);

            if (foundBattery == null)
            {
                foundBattery = new Battery { Capacity = battery.Capacity, Type = battery.Type };
            }

            return foundBattery;
        }

        private Display GetDisplay(Display display)
        {
            var foundDisplay = this.db
                .Displays
                .All()
                .FirstOrDefault(
                    d => d.Resolution == display.Resolution &&
                    d.Size == display.Size &&
                    d.Type == display.Type);

            if (foundDisplay == null)
            {
                foundDisplay = new Display { Resolution = display.Resolution, Size = display.Size, Type = display.Type };
            }

            return foundDisplay;
        }

        private Processor GetProcessor(Processor processor)
        {
            var foundProcessor = this.db
                .Processors
                .All()
                .FirstOrDefault(
                    p => p.CacheMemory == processor.CacheMemory &&
                    p.ClockSpeed == processor.ClockSpeed);

            if (foundProcessor == null)
            {
                foundProcessor = new Processor { CacheMemory = processor.CacheMemory, ClockSpeed = processor.ClockSpeed };
            }

            return foundProcessor;
        }
    }
}