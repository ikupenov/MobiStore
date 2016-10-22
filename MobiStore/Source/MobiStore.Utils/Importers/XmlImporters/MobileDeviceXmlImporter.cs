using System.IO;
using System.Linq;
using System.Xml.Serialization;

using MobiStore.Data.Contracts;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;
using MobiStore.Utils.Factories;

namespace MobiStore.Utils.Importers.XmlImporters
{
    public class MobileDeviceXmlImporter : XmlImporter
    {
        private MobileDeviceFactory mobileDeviceBuilder;

        public MobileDeviceXmlImporter(IMobiStoreData mobiStoreData, XmlSerializer serializer)
            : base(mobiStoreData, serializer)
        {
            this.mobileDeviceBuilder = new MobileDeviceFactory();
        }

        public override void Import(string xmlFilePath)
        {
            using (var fileStream = new FileStream(xmlFilePath, FileMode.Open))
            {
                var shop = (XmlModels.Shop)this.Serializer.Deserialize(fileStream);
                var mobileDevices = shop.MobileDevices.ToList();

                foreach (XmlModels.MobileDevices.MobileDevice mobileDevice in mobileDevices)
                {
                    Battery battery = this.mobileDeviceBuilder.CreateBattery(
                        mobileDevice.Battery.Type,
                        mobileDevice.Battery.Capacity);
                    this.MobiStoreData.Batteries.Add(battery);

                    Display display = this.mobileDeviceBuilder.CreateDisplay(
                        mobileDevice.Display.Type,
                        mobileDevice.Display.Size,
                        mobileDevice.Display.Resolution);
                    this.MobiStoreData.Displays.Add(display);

                    Processor processor = this.mobileDeviceBuilder.CreateProcessor(
                        mobileDevice.Processor.CacheMemory,
                        mobileDevice.Processor.ClockSpeed);
                    this.MobiStoreData.Processors.Add(processor);

                    MobileDevice mobileDeviceToAdd = this.mobileDeviceBuilder.CreateMobileDevice(
                        mobileDevice.Brand,
                        mobileDevice.Model,
                        battery,
                        display,
                        processor);
                    this.MobiStoreData.MobileDevices.Add(mobileDeviceToAdd);
                }

                this.MobiStoreData.SaveChanges();
            }
        }
    }
}