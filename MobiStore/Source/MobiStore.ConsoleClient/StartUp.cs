using System.IO;
using System.IO.Compression;

using MobiStore.Data;
using MobiStore.Utils.Exporters;
using MobiStore.Utils.Importers;
using MobiStore.MongoDB;
using MobiStore.Models.Common;
using MongoDB.Bson;
using MongoDB.Driver;

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
            var db = MongoDb.GetInstance("mongodb://localhost:27017", "MobiStore");
            var countries = db.GetCollection<Country>("countries");

            var list = countries.Find(_ => true).ToList();
            System.Console.WriteLine(list.Count);
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