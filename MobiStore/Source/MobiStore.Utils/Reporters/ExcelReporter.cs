using System.IO;
using System.Linq;

using MobiStore.MySqlDatabase;
using MobiStore.SqliteDatabase;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace MobiStore.Utilities.Reporters
{
    public class ExcelReporter
    {
        public static void CreateReports(MySqlDb mySqlDatabase, SqliteDb sqliteDb, FileInfo fileInfo)
        {
            var allReports = mySqlDatabase.SalesRepository
                .All()
                .Select(x => x)
                .ToList();

            var allShops = sqliteDb.Shops
                .GroupBy(x => new { x.Name, x.Town })
                .ToList()
                .Select(x => x.FirstOrDefault());

            using (var writer = new ExcelPackage(fileInfo))
            {
                foreach (var shop in allShops)
                {
                    var worksheetName = $"{shop.Name} - {shop.Town}";

                    var isExisting =
                        writer.Workbook.Worksheets.SingleOrDefault(x => x.Name == worksheetName) == null ? false : true;

                    if (isExisting)
                    {
                        writer.Workbook.Worksheets.Delete(worksheetName);
                    }

                    ExcelWorksheet ws = writer.Workbook.Worksheets.Add(worksheetName);

                    ws.Cells["A1"].Value = "Employee";
                    ws.Cells["B1"].Value = "Product";
                    ws.Cells["C1"].Value = "Date";
                    ws.Cells["D1"].Value = "Revenue";

                    ws.Cells["A1,B1,C1,D1"].Style.Font.Bold = true;
                    ws.Cells["A1,B1,C1,D1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    ws.Column(1).Width = 15;
                    ws.Column(2).Width = 15;
                    ws.Column(3).Width = 10;

                    var rowCounter = 2;
                    var shopReports = allReports.Where(x => x.Shop == shop.Name);
                    foreach (var shopReport in shopReports)
                    {
                        var rowCounterAsString = rowCounter.ToString();

                        ws.Cells["A" + rowCounterAsString].Value = shopReport.Employee;
                        ws.Cells["B" + rowCounterAsString].Value = shopReport.Product;
                        ws.Cells["C" + rowCounterAsString].Value =
                            $"{shopReport.Date.Day}/{shopReport.Date.Month}/{shopReport.Date.Year}";
                        ws.Cells["D" + rowCounterAsString].Value = shopReport.TotalValue;

                        rowCounter++;
                    }
                }

                writer.Save();
            }
        }
    }
}