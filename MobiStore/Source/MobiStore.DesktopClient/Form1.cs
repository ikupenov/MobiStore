using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Xml.Serialization;

using MobiStore.Data;
using MobiStore.Utilities.Importers;
using MobiStore.MongoDatabase;
using MobiStore.Factories.Factories;
using MobiStore.SqliteDatabase;
using MobiStore.Utilities.Reporters;
using MobiStore.Utilities.Importers.XmlImporters;

namespace MobiStore.DesktopClient
{
    public partial class Form1 : Form
    {
        private const string PathOfZip = "../../DataFiles/Zips/Input.zip";
        private const string ExtractedFilePath = "../../DataFiles/Excels";
        private const string MongoServerName = "mongodb://localhost:27017";
        private const string MongoDatabaseName = "MobiStore";

        public Form1()
        {
            SqlServerDb.Initialize();
            InitializeComponent();
        }

        private void LoadExcelReportsButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo root = new DirectoryInfo(ExtractedFilePath);
            if (root.GetDirectories().Length == 0)
            {
                ZipFile.ExtractToDirectory(PathOfZip, ExtractedFilePath);
            }

            ExcelImporter.ImportReports(root, new SqlServerDb());
        }

        private void LoadDataFromMongoButton_Click(object sender, EventArgs e)
        {
            this.SeedMongo();
            var sqlserverDb = new SqlServerDb();
            var mssqlFactory = new MsSqlModelsFactory(sqlserverDb);
            var mongo = new MongoDb(mssqlFactory);
            var mongoDb = MongoDb.GetInstance(MongoServerName, MongoDatabaseName);

            mongo.TransferToSqlServer(mongoDb, sqlserverDb);
        }

        private void GenerateXmlReportsButton_Click(object sender, EventArgs e)
        {
            var destinationDir = new DirectoryInfo("../../DataFiles/Xmls/CreatedReports");
            XmlReporter.CreateReports(new SqlServerDb(), new XmlSerializer(typeof(XmlModels.Reporters.SalesReport)), destinationDir);
        }

        private void GenerateJsonReportsButton_Click(object sender, EventArgs e)
        {
            var currentDir = Directory.GetCurrentDirectory();
            var destinationDir = new DirectoryInfo("../../DataFiles/Jsons/CreatedReports");
            JsonReporter.CreateReports(new SqlServerDb(), destinationDir);
        }

        private void LoadDataFromXmlButton_Click(object sender, EventArgs e)
        {
            var sqlServerDb = new SqlServerDb();
            var mongoDb = MongoDb.GetInstance(MongoServerName, MongoDatabaseName);
            var currentDir = Directory.GetCurrentDirectory();
            var shopXmlDir = new DirectoryInfo($@"{currentDir}\..\..\..\..\Data\Models\shop.xml");
            var xmlSerializer = new XmlSerializer(typeof(XmlModels.Shop));
            var mobileDeviceXmlImporter = new MobileDeviceXmlImporter(sqlServerDb, mongoDb, xmlSerializer);

            mobileDeviceXmlImporter.Import(shopXmlDir);
            Console.WriteLine();
        }

        private void SQLiteButton_Click(object sender, EventArgs e)
        {
            SqliteSeeder.SeedDatabase();
        }

        private void SeedMongo()
        {
            var seeder = new MongoSeeder(new MongoModelsFactory());
            seeder.SeedDatabase(MongoServerName, MongoDatabaseName);
        }
    }
}