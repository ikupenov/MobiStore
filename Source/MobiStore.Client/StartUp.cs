using MobiStore.Data;
using MobiStore.Models.Enumerations;
using MobiStore.Models.MobileDevices.Components;

namespace MobiStore.Client
{
    public class StartUp
    {
        public static void Main()
        {
            MobiStoreData.Initialize();
            var data = new MobiStoreData();

            var battery = new Battery { Capacity = 10, Type = BatteryType.AAMI };
            data.Batteries.Add(battery);
            data.SaveChanges();
        }
    }
}