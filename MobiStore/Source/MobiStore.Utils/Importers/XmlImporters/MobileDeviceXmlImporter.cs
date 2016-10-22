using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

using MobiStore.Data.Contracts;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;
using MobiStore.Utils.Factories;
using MongoDB.Driver;

namespace MobiStore.Utils.Importers.XmlImporters
{
    public class MobileDeviceXmlImporter : XmlImporter
    {
        private MobileDeviceFactory mobileDeviceFactory;

        public MobileDeviceXmlImporter(IMobiStoreData sqlServerData, IMongoDatabase mongoData, XmlSerializer serializer)
            : base(sqlServerData, mongoData, serializer)
        {
            this.mobileDeviceFactory = new MobileDeviceFactory();
        }

        public override void Import(string xmlFilePath)
        {
            using (var fileStream = new FileStream(xmlFilePath, FileMode.Open))
            {
                var shop = (XmlModels.Shop)this.XmlSerializer.Deserialize(fileStream);
                var mobileDevices = shop.MobileDevices.ToList();

                var batteriesToInsert = new List<Battery>(mobileDevices.Count);
                var displaysToInsert = new List<Display>(mobileDevices.Count);
                var processorsToInsert = new List<Processor>(mobileDevices.Count);
                var mobileDevicesToInsert = new List<MobileDevice>(mobileDevices.Count);

                foreach (var mobileDevice in mobileDevices)
                {
                    Battery battery = this.mobileDeviceFactory.CreateBattery(
                        mobileDevice.Battery.Type,
                        mobileDevice.Battery.Capacity);

                    batteriesToInsert.Add(battery);
                    this.SqlServerDatabase.Batteries.Add(battery);

                    Display display = this.mobileDeviceFactory.CreateDisplay(
                        mobileDevice.Display.Type,
                        mobileDevice.Display.Size,
                        mobileDevice.Display.Resolution);

                    this.SqlServerDatabase.Displays.Add(display);
                    displaysToInsert.Add(display);

                    Processor processor = this.mobileDeviceFactory.CreateProcessor(
                        mobileDevice.Processor.CacheMemory,
                        mobileDevice.Processor.ClockSpeed);

                    this.SqlServerDatabase.Processors.Add(processor);
                    processorsToInsert.Add(processor);

                    MobileDevice mobileDeviceToImport = this.mobileDeviceFactory.CreateMobileDevice(
                        mobileDevice.Brand,
                        mobileDevice.Model,
                        battery,
                        display,
                        processor);

                    this.SqlServerDatabase.MobileDevices.Add(mobileDeviceToImport);
                    mobileDevicesToInsert.Add(mobileDeviceToImport);
                }

                this.InsertCollectionToMongoAsync<Battery>(batteriesToInsert, "batteries");
                this.InsertCollectionToMongoAsync<Display>(displaysToInsert, "displays");
                this.InsertCollectionToMongoAsync<Processor>(processorsToInsert, "processors");
                this.InsertCollectionToMongoAsync<MobileDevice>(mobileDevicesToInsert, "mobileDevices");

                this.SqlServerDatabase.SaveChanges();
            }
        }

        private async void InsertCollectionToMongoAsync<T>(IEnumerable<object> collectionToInsert, string documentName)
        {
            var collection = this.MongoDatabase.GetCollection<T>(documentName);
            await collection.InsertManyAsync(collectionToInsert as IEnumerable<T>);
        }
    }
}