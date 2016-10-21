using System;
using System.IO;
using System.Xml.Serialization;

using MobiStore.Data.Contracts;
using MobiStore.Models;
using MobiStore.Utils.Contracts;
using System.Linq;
using MobiStore.Data;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;

namespace MobiStore.Utils.Importers
{
    public class XmlImporter : IXmlImporter
    {
        private const string NullExceptionMessage = "The provided parameter [{0}] in {1}'s constructor cannot be null.";

        private IMobiStoreData mobiStoreData;
        private XmlSerializer serializer;

        public XmlImporter(IMobiStoreData mobiStoreData, XmlSerializer serializer)
        {
            if (mobiStoreData == null)
            {
                var exceptionMsg = string.Format(NullExceptionMessage, mobiStoreData.GetType().Name, this.GetType().Name);
                throw new ArgumentNullException(exceptionMsg);
            }

            if (serializer == null)
            {
                var exceptionMsg = string.Format(NullExceptionMessage, serializer.GetType().Name, this.GetType().Name);
                throw new ArgumentNullException(exceptionMsg);
            }

            this.mobiStoreData = mobiStoreData;
            this.serializer = serializer;
        }

        public void Import(string xmlFilePath)
        {
            using (var fileStream = new FileStream(xmlFilePath, FileMode.Open))
            {
                var shop = (Shop)this.serializer.Deserialize(fileStream);
                var devices = shop.MobileDevices.ToList();

                foreach (var mobileDevice in devices)
                {
                    var battery = new Battery
                    {
                        Type = mobileDevice.Battery.Type,
                        TypeAsString = mobileDevice.Battery.TypeAsString,
                        Capacity = mobileDevice.Battery.Capacity        
                    };

                    this.mobiStoreData.Batteries.Add(battery);

                    var display = new Display
                    {
                        Resolution = mobileDevice.Display.Resolution,
                        Size = mobileDevice.Display.Size,
                        TypeAsString = mobileDevice.Display.TypeAsString,
                        Type = mobileDevice.Display.Type
                    };
                    this.mobiStoreData.Displays.Add(display);

                    var processor = new Processor
                    {
                        CacheMemory = mobileDevice.Processor.CacheMemory,
                        ClockSpeed = mobileDevice.Processor.ClockSpeed
                    };
                    this.mobiStoreData.Processors.Add(processor);

                    var deviceToAdd = new MobileDevice
                    {
                        Battery = battery,
                        Display = display,
                        Processor = processor,
                        Brand = mobileDevice.Brand,
                        BrandAsString = mobileDevice.BrandAsString,
                        Model = mobileDevice.Model
                    };

                    this.mobiStoreData.MobileDevices.Add(deviceToAdd);
                }

                this.mobiStoreData.SaveChanges();
            }
        }
    }
}