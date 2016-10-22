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
                var shop = (XmlModels.Shop)this.XmlSerializer.Deserialize(fileStream);
                var mobileDevices = shop.MobileDevices.ToList();

                var batteries = this.MongoDatabase.GetCollection<Battery>("batteries");
                var displays = this.MongoDatabase.GetCollection<Display>("displays");
                var processors = this.MongoDatabase.GetCollection<Processor>("processors");
                var devices = this.MongoDatabase.GetCollection<MobileDevice>("mobileDevices");

                var batteriesToImportInMongo = new List<Battery>(mobileDevices.Count);
                var displaysToImportInMongo = new List<Display>(mobileDevices.Count);
                var processorsToImportInMongo = new List<Processor>(mobileDevices.Count);
                var mobileDevicesToImportInMongo = new List<MobileDevice>(mobileDevices.Count);

                var mongoBatteries = new List<Battery>(mobileDevices.Count);

                foreach (XmlModels.MobileDevices.MobileDevice mobileDevice in mobileDevices)
                {
                    Battery battery = this.mobileDeviceBuilder.CreateBattery(
                        mobileDevice.Battery.Type,
                        mobileDevice.Battery.Capacity);

                    //Battery mongoBattery = this.mobileDeviceBuilder.CreateBattery(
                    //   battery.Type,
                    //   battery.Capacity);

                    Battery mongoBattery = new Battery
                    {
                        Type = battery.Type,
                        Capacity = battery.Capacity
                    };

                    batteriesToImportInMongo.Add(battery);
                    mongoBatteries.Add(mongoBattery);
                    this.SqlServerDatabase.Batteries.Add(battery);

                    Display display = this.mobileDeviceBuilder.CreateDisplay(
                        mobileDevice.Display.Type,
                        mobileDevice.Display.Size,
                        mobileDevice.Display.Resolution);
                    this.SqlServerDatabase.Displays.Add(display);

                    Display mongoDisplay = new Display
                    {
                       Size = display.Size,
                       Type = display.Type,
                       Resolution = display.Resolution
                    };
                    displaysToImportInMongo.Add(mongoDisplay);

                    Processor processor = this.mobileDeviceBuilder.CreateProcessor(
                        mobileDevice.Processor.CacheMemory,
                        mobileDevice.Processor.ClockSpeed);
                    this.SqlServerDatabase.Processors.Add(processor);

                    Processor mongoProcessor = new Processor
                    {
                        CacheMemory = processor.CacheMemory,
                        ClockSpeed = processor.ClockSpeed
                    };
                    processorsToImportInMongo.Add(mongoProcessor);

                    MobileDevice mobileDeviceToImport = this.mobileDeviceBuilder.CreateMobileDevice(
                        mobileDevice.Brand,
                        mobileDevice.Model,
                        battery,
                        display,
                        processor);
                    this.SqlServerDatabase.MobileDevices.Add(mobileDeviceToImport);

                    MobileDevice mongoDevice = new MobileDevice
                    {
                        Model = mobileDeviceToImport.Model,
                        Brand = mobileDeviceToImport.Brand,
                        Battery = mongoBattery,
                        Display = mongoDisplay,
                        Processor = mongoProcessor
                    };
                    mobileDevicesToImportInMongo.Add(mongoDevice);
                }

                batteries.InsertMany(mongoBatteries);
                batteries.InsertMany(batteriesToImportInMongo);
                displays.InsertMany(displaysToImportInMongo);
                processors.InsertMany(processorsToImportInMongo);
                devices.InsertMany(mobileDevicesToImportInMongo);

                this.SqlServerDatabase.SaveChanges();
            }
        }
    }
}