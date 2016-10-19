using System.Data;
using System.Data.OleDb;
using System.IO;
using System.IO.Compression;
using Excel = Microsoft.Office.Interop.Excel;

namespace MobiStore.Utils.Readers
{
    public class ExcelReader
    {
        private const string OleDbConnectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties = Excel 12.0;";
        private const string SelectTableQuery = "select * from [{0}$]";

        private static void UnzipFile(string zipFilePath, string destinationFolder)
        {
            ZipFile.ExtractToDirectory(zipFilePath, destinationFolder);
        }

        private static void TraverseDirectory(DirectoryInfo directory)
        {
            DirectoryInfo[] childDirectories = directory.GetDirectories();
            foreach (DirectoryInfo dir in childDirectories)
            {
                TraverseDirectory(dir);
            }

            FileInfo[] directoryFiles = directory.GetFiles();
            foreach (FileInfo file in directoryFiles)
            {
                string excelFilePath = file.FullName;
                string connectionString = string.Format(OleDbConnectionString, excelFilePath);
                Excel.Application excelApplication = new Excel.Application();
                Excel.Workbook excelWorkbook = excelApplication.Workbooks.Open(excelFilePath);
                Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];
                DataTable excelData = ReadExcelData(excelFilePath, connectionString, excelWorksheet.Name);

                foreach (DataRow row in excelData.Rows)
                {
                    CreateReport(row);
                }
            }
        }

        private static void CreateReport(DataRow row)
        {
            // TODO: Create sales report instance 
        }

        private static DataTable ReadExcelData(string excelFilePath, string connectionString, string workSheetName)
        {
            OleDbConnection excelConnection = new OleDbConnection(string.Format(connectionString, excelFilePath));
            DataTable dataTable = new DataTable();

            excelConnection.Open();
            string selectQuery = string.Format(SelectTableQuery, workSheetName);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(selectQuery, excelConnection);

            dataAdapter.Fill(dataTable);
            excelConnection.Close();

            return dataTable;
        }
    }
}