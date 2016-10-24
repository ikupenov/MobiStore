using MobiStore.Models.Enumerations;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;

namespace MobiStore.Factories.Contracts
{
    public interface IModelsFactory
    {
        Battery CreateBattery(BatteryType type, int capacity);

        Display CreateDisplay(DisplayType type, double size, string resolution);

        Processor CreateProcessor(double clockSpeed, double cacheMemory);

        MobileDevice CreateMobileDevice(
            Brand brand,
            string model,
            Display display = null,
            Battery battery = null,
            Processor processor = null);
    }
}