using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;

using MobiStore.Data;
using MobiStore.MongoDatabase;
using MobiStore.MySqlDatabase;
using MobiStore.Utilities.Reporters;
using MobiStore.Utilities.Importers;
using MobiStore.Utilities.Importers.XmlImporters;

namespace MobiStore.ConsoleClient
{
    public class StartUp
    {
        private const string PathOfZip = "../../DataFiles/Zips/Input.zip";
        private const string ExtractedFilePath = "../../DataFiles/Excels";

        private static void Main()
        {
            //CreateDatabase();

            //var seeder = new MongoSeeder();

            //seeder.SeedDatabase("mongodb://localhost:27017", "MobiStore");
            //var mongoDb = MongoDb.GetInstance("mongodb://localhost:27017", "MobiStore");
            var sqlServerDb = new SqlServerDb();
            //var mongo = new MongoDb();

            //mongo.TransferToSqlServer(mongoDb, sqlServerDb);

            //var xmlSerializer = new XmlSerializer(typeof(XmlModels.Shop));
            //var mobileDeviceXmlImporter = new MobileDeviceXmlImporter(sqlServerDb, mongoDb, xmlSerializer);

            //var currentDir = Directory.GetCurrentDirectory();
            //var shopXmlDir = new DirectoryInfo($@"{currentDir}\..\..\..\..\Data\Models\shop.xml");
            //mobileDeviceXmlImporter.Import(shopXmlDir);

            ReadExcelReports();
            //CreateXmlReports();

            var mySqlDatabase = new MySqlDb();
            MySqlSeeder.SeedDatabase(sqlServerDb, mySqlDatabase);
        }

        private static void CreateDatabase()
        {
            SqlServerDb.Initialize();
            SqlServerContext.Create().Database.Initialize(true);
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