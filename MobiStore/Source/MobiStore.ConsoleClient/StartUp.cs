using System;
using System.IO;
using System.Xml.Serialization;

using MobiStore.Data;
using MobiStore.Utils.Importers;
using MobiStore.Models;
using MobiStore.Models.MobileDevices;
using MobiStore.Utils.Exporters;
using MobiStore.Utils.Importers.XmlImporters;

namespace MobiStore.ConsoleClient
{
    public class StartUp
    {
        private const string PathOfZip = "../../DataFiles/Zips/Input.zip";
        private const string ExtractedFilePath = "../../DataFiles/Excels";

        private static void Main()
        {
            // ZipFile.ExtractToDirectory(PathOfZip, ExtractedFilePath);
            //DirectoryInfo root = new DirectoryInfo(ExtractedFilePath);
            //ExcelImporter.ImportReports(root, new MobiStoreData());

            MobiStoreData.Initialize();
            MobiStoreDbContext.Create().Database.Initialize(true);

            //DirectoryInfo jsonDirectory = new DirectoryInfo("../../DataFiles/Jsons");
            //JsonReporter.CreateReports(new MobiStoreData(), jsonDirectory);

            var xmlImporter = new MobileDeviceXmlImporter(new MobiStoreData(), new XmlSerializer(typeof(Shop)));
            xmlImporter.Import(@"..\..\..\..\Data\Models\shop.xml");
        }
    }
}