using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;

using MobiStore.Data;
using MobiStore.MongoDatabase;
using MobiStore.MySqlDatabase;
using MobiStore.Utilities.Reporters;
using MobiStore.Utilities.Importers;
using MobiStore.Utilities.Importers.XmlImporters;
using MobiStore.Factories;
using MobiStore.Factories.Factories;
using MobiStore.Models.MobileDevices;
using MobiStore.SqliteDatabase;
using MongoDB.Driver;

namespace MobiStore.ConsoleClient
{
    public class StartUp
    {
        private const string PathOfZip = "../../DataFiles/Zips/Input.zip";
        private const string ExtractedFilePath = "../../DataFiles/Excels";
        private const string MongoServerName = "mongodb://localhost:27017";
        private const string MongoDatabaseName = "MobiStore";

        private static void Main()
        {
            SqlServerDb.Initialize();

            //// ================ SEED MONGO ======================
            //var seeder = new MongoSeeder(new MongoModelsFactory());
            //seeder.SeedDatabase(MongoServerName, MongoDatabaseName);
            //var mongoDb = MongoDb.GetInstance(MongoServerName, MongoDatabaseName);
            //var all = mongoDb.GetCollection<MobileDevice>("mobileDevices").Find(b => true).ToList();
            //System.Console.WriteLine();

            //// ================= TRANSFER MONGO DATA TO MSSQL SERVER =============
            //var sqlServerDb = new SqlServerDb();
            //var mongoDbInstance = MongoDb.GetInstance(MongoServerName, MongoDatabaseName);
            //var mongoDb = new MongoDb(new MsSqlModelsFactory(sqlServerDb));
            //mongoDb.TransferToSqlServer(mongoDbInstance, sqlServerDb);

            //var xmlSerializer = new XmlSerializer(typeof(XmlModels.Shop));
            //var mobileDeviceXmlImporter = new MobileDeviceXmlImporter(sqlServerDb, mongoDb, xmlSerializer);

            //var currentDir = Directory.GetCurrentDirectory();
            //var shopXmlDir = new DirectoryInfo($@"{currentDir}\..\..\..\..\Data\Models\shop.xml");
            //mobileDeviceXmlImporter.Import(shopXmlDir);

            //ReadExcelReports();
            //CreateXmlReports();

            //var mySqlDatabase = new MySqlDb();
            //MySqlSeeder.SeedDatabase(sqlServerDb, mySqlDatabase);

            SqliteSeeder.SeedDatabase();
        }

        private static void ReadExcelReports()
        {
            DirectoryInfo root = new DirectoryInfo(ExtractedFilePath);
            if (root.GetDirectories().Length == 0)
            {
                ZipFile.ExtractToDirectory(PathOfZip, ExtractedFilePath);
            }

            ExcelImporter.ImportReports(root, new SqlServerDb());
        }

        private static void CreateJsonReports()
        {
            var currentDir = Directory.GetCurrentDirectory();
            var destinationDir = new DirectoryInfo($@"{currentDir}\..\..\..\..\Data\Reports\Output\JSON");
            JsonReporter.CreateReports(new SqlServerDb(), destinationDir);
        }

        private static void CreateXmlReports()
        {
            var currentDir = Directory.GetCurrentDirectory();
            var destinationDir = new DirectoryInfo($@"{currentDir}\..\..\..\..\Data\Reports\Output\XML");
            XmlReporter.CreateReports(new SqlServerDb(), new XmlSerializer(typeof(XmlModels.Reporters.SalesReport)), destinationDir);
        }
    }
}