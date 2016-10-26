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
using MobiStore.Utils.Reporters;

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

        private const string PdfReportsCreatedSuccessfully = "PDF reports are created successfully.";
        private const string ExcelReportsLoadedSuccessfully = "Excel reports are loaded successfully.";
        private const string DataLoadedFromMongoSuccessfully = "MongoDb data is transferred successfully to MSSQL Server.";
        private const string XmlReportsAreGeneratedSuccessfuly = "XML reports are created successfully.";
        private const string JsonReportsAreGeneratedSuccessfuly = "JSON reports are created successfully.";
        private const string DataLoadedFromXmlSuccessfully = "Data from XML is loaded successfully.";
        private const string ReportsFromSQLiteAndMySQLCreatedSuccessfully =
            "Reports from SQLite and MySQL are created successfully.";

        public MainWindow()
        {
            SqlServerDb.Initialize();
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void LoadExcelReportsButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo root = new DirectoryInfo(ExtractedFilePath);
            if (root.GetDirectories().Length == 0)
            {
                ZipFile.ExtractToDirectory(PathOfZip, ExtractedFilePath);
            }

            ExcelImporter.ImportReports(root, new SqlServerDb());
            MessageBox.Show(ExcelReportsLoadedSuccessfully, string.Empty, MessageBoxButtons.OK);
        }

        private void LoadDataFromMongoButton_Click(object sender, EventArgs e)
        {
            this.SeedMongo();
            var sqlserverDb = new SqlServerDb();
            var mssqlFactory = new MsSqlModelsFactory(sqlserverDb);
            var mongo = new MongoDb(mssqlFactory);
            var mongoDb = MongoDb.GetInstance(MongoServerName, MongoDatabaseName);

            mongo.TransferToSqlServer(mongoDb, sqlserverDb);
            MessageBox.Show(DataLoadedFromMongoSuccessfully, string.Empty, MessageBoxButtons.OK);
        }

        private void PdfReportButton_Click(object sender, EventArgs e)
        {
            var currentDir = Directory.GetCurrentDirectory();
            string pdfOuputPath = $@"{currentDir}\..\..\DataFiles\Pdfs\report.pdf";
            var reporter = new PdfReporter();

            reporter.CreateReport(pdfOuputPath);
            MessageBox.Show(PdfReportsCreatedSuccessfully, string.Empty, MessageBoxButtons.OK);
        }

        private void GenerateXmlReportsButton_Click(object sender, EventArgs e)
        {
            var destinationDir = new DirectoryInfo(XmlReportsFolderPath);
            XmlReporter.CreateReports(new SqlServerDb(), new XmlSerializer(typeof(XmlModels.Reporters.SalesReport)), destinationDir);
            MessageBox.Show(XmlReportsAreGeneratedSuccessfuly, string.Empty, MessageBoxButtons.OK);
        }

        private void GenerateJsonReportsButton_Click(object sender, EventArgs e)
        {
            var currentDir = Directory.GetCurrentDirectory();
            var destinationDir = new DirectoryInfo(JsonOutputReports);
            JsonReporter.CreateReports(new SqlServerDb(), destinationDir);
            MessageBox.Show(JsonReportsAreGeneratedSuccessfuly, string.Empty, MessageBoxButtons.OK);
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
            MessageBox.Show(DataLoadedFromXmlSuccessfully, string.Empty, MessageBoxButtons.OK);
        }

        private void SQLiteButton_Click(object sender, EventArgs e)
        {
            SqliteSeeder.SeedDatabase();

            string password = Prompt.ShowDialog("Please enter MySQL password: ", string.Empty);
            var mysqlDb = new MySqlDb(password);
            MySqlSeeder.SeedDatabase(new SqlServerDb(), mysqlDb);

            var fileInfo = new FileInfo(ExcelOutputReports);
            ExcelReporter.CreateReports(mysqlDb, new SqliteDb(), fileInfo);

            MessageBox.Show(ReportsFromSQLiteAndMySQLCreatedSuccessfully, string.Empty, MessageBoxButtons.OK);
        }

        private void SeedMongo()
        {
            var seeder = new MongoSeeder(new MongoModelsFactory());
            seeder.SeedDatabase(MongoServerName, MongoDatabaseName);
        }
    }
}