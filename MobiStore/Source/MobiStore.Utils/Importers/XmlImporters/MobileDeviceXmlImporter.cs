using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

using MobiStore.Data.Contracts;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;
using MobiStore.Utils.Factories;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace MobiStore.Utils.Importers.XmlImporters
{
    public class MobileDeviceXmlImporter : XmlImporter
    {
        private MobileDeviceFactory mobileDeviceBuilder;

        public MobileDeviceXmlImporter(IMobiStoreData sqlServerData, IMongoDatabase mongoData, XmlSerializer serializer)
            : base(sqlServerData, mongoData, serializer)
        {
            this.mobileDeviceBuilder = new MobileDeviceFactory();
        }

        public override void Import(string xmlFilePath)
        {
            using (var fileStream = new FileStream(xmlFilePath, FileMode.Open))
            {
                var batteriesToImportInMongo = new LinkedList<Battery>();
                var displaysToImportInMongo = new LinkedList<Display>();
                var processorsToImportInMongo = new LinkedList<Processor>();
                var mobileDevicesToImportInMongo = new LinkedList<MobileDevice>();

                var shop = (XmlModels.Shop)this.XmlSerializer.Deserialize(fileStream);
                var mobileDevices = shop.MobileDevices.ToList();

                foreach (var mobileDevice in mobileDevices)
                {
                    Battery battery = this.mobileDeviceBuilder.CreateBattery(
                        mobileDevice.Battery.Type,
                        mobileDevice.Battery.Capacity);
                    this.SqlServerDatabase.Batteries.Add(battery);

                    var batteryAsBson = BsonSerializer.Deserialize<Battery>(battery);
                    batteriesToImportInMongo.AddLast(batteryAsBson);

                    Display display = this.mobileDeviceBuilder.CreateDisplay(
                        mobileDevice.Display.Type,
                        mobileDevice.Display.Size,
                        mobileDevice.Display.Resolution);
                    this.SqlServerDatabase.Displays.Add(display);

                    var displayAsJson = JsonConvert.SerializeObject(display);
                    var displayAsBson = BsonSerializer.Deserialize<Display>(displayAsJson);
                    displaysToImportInMongo.AddLast(displayAsBson);

                    Processor processor = this.mobileDeviceBuilder.CreateProcessor(
                        mobileDevice.Processor.CacheMemory,
                        mobileDevice.Processor.ClockSpeed);
                    this.SqlServerDatabase.Processors.Add(processor);

                    var processorAsJson = JsonConvert.SerializeObject(processor);
                    var processorAsBson = BsonSerializer.Deserialize<Processor>(processorAsJson);
                    processorsToImportInMongo.AddLast(processorAsBson);

                    MobileDevice mobileDeviceToImport = this.mobileDeviceBuilder.CreateMobileDevice(
                        mobileDevice.Brand,
                        mobileDevice.Model,
                        battery,
                        display,
                        processor);
                    this.SqlServerDatabase.MobileDevices.Add(mobileDeviceToImport);

                    //var mobileDeviceAsJson = JsonConvert.SerializeObject(mobileDeviceToImport);
                    //var mobileDeviceAsBson = BsonSerializer.Deserialize<BsonDocument>(mobileDeviceAsJson);
                    //mobileDevicesToImportInMongo.AddLast(mobileDeviceAsBson);
                }

                this.ImportManyToMongoAsync<Battery>(batteriesToImportInMongo, "batteries");
                this.ImportManyToMongoAsync<Display>(displaysToImportInMongo, "displays");
                this.ImportManyToMongoAsync<Processor>(processorsToImportInMongo, "processors");

                this.SqlServerDatabase.SaveChanges();
            }
        }

        private async void ImportManyToMongoAsync<T>(IEnumerable<object> collectionToImport, string documentName)
        {
            var collection = this.MongoDatabase.GetCollection<T>(documentName);
            await collection.InsertManyAsync(collectionToImport as IEnumerable<T>);
        }
    }
}