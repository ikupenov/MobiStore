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

            using (var excelPackage = new ExcelPackage(fileInfo))
            {
                foreach (var shop in allShops)
                {
                    var worksheetName = $"{shop.Name} - {shop.Town}";

                    var isExisting = excelPackage.Workbook.Worksheets.Any(x => x.Name == worksheetName);
                    if (isExisting)
                    {
                        excelPackage.Workbook.Worksheets.Delete(worksheetName);
                    }

                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(worksheetName);

                    worksheet.Cells["A1"].Value = "Employee";
                    worksheet.Cells["B1"].Value = "Product";
                    worksheet.Cells["C1"].Value = "Date";
                    worksheet.Cells["D1"].Value = "Revenue";

                    worksheet.Cells["A1,B1,C1,D1"].Style.Font.Bold = true;
                    worksheet.Cells["A1,B1,C1,D1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    worksheet.Column(1).Width = 15;
                    worksheet.Column(2).Width = 15;
                    worksheet.Column(3).Width = 10;

                    int rowCounter = 2;
                    var rowCounterAsString = rowCounter.ToString();

                    decimal totalRevenue = 0;

                    var shopReports = allReports.Where(x => x.Shop == shop.Name).OrderBy(x => x.Date);
                    foreach (var shopReport in shopReports)
                    {
                        var shopReportDate = shopReport.Date;

                        worksheet.Cells["A" + rowCounterAsString].Value = shopReport.Employee;
                        worksheet.Cells["B" + rowCounterAsString].Value = shopReport.Product;
                        worksheet.Cells["C" + rowCounterAsString].Value = $"{shopReportDate.Day}/{shopReportDate.Month}/{shopReportDate.Year}";
                        worksheet.Cells["D" + rowCounterAsString].Value = shopReport.TotalValue;

                        totalRevenue += shopReport.TotalValue;

                        rowCounter++;
                        rowCounterAsString = rowCounter.ToString();
                    }

                    {
                        var currRowCellA = "A" + rowCounterAsString;
                        var currRowCellB = "B" + rowCounterAsString;
                        var currRowCellC = "C" + rowCounterAsString;
                        var currRowCellD = "D" + rowCounterAsString;

                        worksheet.Cells[$"{currRowCellA}:{currRowCellB}"].Merge = true;
                        worksheet.Cells[$"{currRowCellA}:{currRowCellB}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        worksheet.Cells[$"{currRowCellA}:{currRowCellB}"].Value = "Total Revenue: ";
                        worksheet.Cells[currRowCellD].Value = totalRevenue;

                        worksheet.Cells[$"{currRowCellD}"].Style.Font.Bold = true;
                        worksheet.Cells[$"{currRowCellA},{currRowCellB},{currRowCellC},{currRowCellD}"].Style.Border
                           .Top.Style = ExcelBorderStyle.Thick;
                        worksheet.Cells[$"{currRowCellA},{currRowCellB},{currRowCellC},{currRowCellD}"].Style.Border
                            .Bottom.Style = ExcelBorderStyle.Thick;
                    }
                }

                excelPackage.Save();
            }
        }
    }
}