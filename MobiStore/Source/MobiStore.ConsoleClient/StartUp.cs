﻿using System;
using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;

using MobiStore.Data;
using MobiStore.MongoDB;
using MobiStore.Utils.Exporters;
using MobiStore.Utils.Importers;
using MobiStore.Utils.Importers.XmlImporters;

namespace MobiStore.ConsoleClient
{
    public class StartUp
    {
        private const string PathOfZip = "../../DataFiles/Zips/Input.zip";
        private const string ExtractedFilePath = "../../DataFiles/Excels";

        private static void Main()
        {
            CreateDatabase();

            var seeder = new MongoSeeder();

            seeder.SeedDatabase("mongodb://localhost:27017", "MobiStore");
            var mongoDb = MongoDb.GetInstance("mongodb://localhost:27017", "MobiStore");
            var sqlServerDb = new MobiStoreData();
            var mongo = new MongoDb();

            mongo.TransferToSqlServer(mongoDb, sqlServerDb);

            var xmlSerializer = new XmlSerializer(typeof(XmlModels.Shop));
            var mobileDeviceXmlImporter = new MobileDeviceXmlImporter(sqlServerDb, mongoDb, xmlSerializer);

            var currentDir = Directory.GetCurrentDirectory();
            mobileDeviceXmlImporter.Import($@"{currentDir}\..\..\..\..\Data\Models\shop.xml");
        }

        private static void CreateDatabase()
        {
            MobiStoreData.Initialize();
            MobiStoreDbContext.Create().Database.Initialize(true);
        }

        private static void ReadExcelReports()
        {
            DirectoryInfo root = new DirectoryInfo(ExtractedFilePath);
            if (root.GetDirectories().Length == 0)
            {
                ZipFile.ExtractToDirectory(PathOfZip, ExtractedFilePath);
            }

            ExcelImporter.ImportReports(root, new MobiStoreData());
        }

        private static void CreateJsonReports()
        {
            DirectoryInfo jsonDirectory = new DirectoryInfo("../../DataFiles/Jsons");
            JsonReporter.CreateReports(new MobiStoreData(), jsonDirectory);
        }
    }
}