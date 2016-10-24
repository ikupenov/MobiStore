using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Xml.Serialization;

using MobiStore.Data;
using MobiStore.Factories.Factories;
using MobiStore.MongoDatabase;
using MobiStore.MySqlDatabase;
using MobiStore.SqliteDatabase;

using MobiStore.Utilities.Importers;
using MobiStore.Utilities.Importers.XmlImporters;
using MobiStore.Utilities.Reporters;

namespace MobiStore.DesktopClient
{
    public partial class MainWindow : Form
    {
        private const string PathOfZip = "../../DataFiles/Zips/Input.zip";
        private const string ExtractedFilePath = "../../DataFiles/Excels";
        private const string MongoServerName = "mongodb://localhost:27017";
        private const string MongoDatabaseName = "MobiStore";
        private const string XmlReportsFolderPath = "../../DataFiles/Xmls/CreatedReports";
        private const string ExcelOutputReports = @"..\..\..\..\Data\Reports\Output\Excel\reports-out.xlsx";
        private const string JsonOutputReports = "../../DataFiles/Jsons/CreatedReports";

        public MainWindow()
        {
            SqlServerDb.Initialize();
            this.InitializeComponent();
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
            var destinationDir = new DirectoryInfo(XmlReportsFolderPath);
            XmlReporter.CreateReports(new SqlServerDb(), new XmlSerializer(typeof(XmlModels.Reporters.SalesReport)), destinationDir);
        }

        private void GenerateJsonReportsButton_Click(object sender, EventArgs e)
        {
            var currentDir = Directory.GetCurrentDirectory();
            var destinationDir = new DirectoryInfo(JsonOutputReports);
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

            var fileInfo = new FileInfo(ExcelOutputReports);
            ExcelReporter.CreateReports(new MySqlDb(), new SqliteDb(), fileInfo);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void SeedMongo()
        {
            var seeder = new MongoSeeder(new MongoModelsFactory());
            seeder.SeedDatabase(MongoServerName, MongoDatabaseName);
        }        
    }
}