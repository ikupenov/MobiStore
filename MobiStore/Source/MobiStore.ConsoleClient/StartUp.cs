using System.IO;

using MobiStore.Data;
using MobiStore.Utils.Importers;
using System;
using MobiStore.Utils.Exporters;

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

            //MobiStoreData.Initialize();
            //MobiStoreDbContext.Create().Database.Initialize(true);

            DirectoryInfo jsonDirectory = new DirectoryInfo("../../DataFiles/Jsons");
            JsonReporter.CreateReports(new MobiStoreData(), jsonDirectory);
        }
    }
}