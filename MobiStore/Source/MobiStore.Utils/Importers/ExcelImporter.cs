using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;

using MobiStore.Data.Contracts;
using MobiStore.Models;
using MobiStore.Models.Enumerations;
using MobiStore.Models.Reports;

namespace MobiStore.Utilities.Importers
{
    public class ExcelImporter
    {
        private const string ExcelFileExtension = ".xls";
        private const string SelectQuery = "Select * from [Sales$]";
        private const string OleDbConnectionString =
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES;IMEX=1;'";

        private const string NullObjectMessage = "{0} cannot be null.";

        public static void ImportReports(DirectoryInfo rootDirectory, ISqlServerDb db)
        {
            string nullRootDirectoryMessage = string.Format(NullObjectMessage, "Excel root directory");
            string nullDatabaseMessage = string.Format(NullObjectMessage, "Database");
            ValidateIfObjectIsNull(rootDirectory, nullRootDirectoryMessage);
            ValidateIfObjectIsNull(db, nullDatabaseMessage);

            TraverseDirectory(rootDirectory, db);
        }

        private static void TraverseDirectory(DirectoryInfo directory, ISqlServerDb db)
        {
            DirectoryInfo[] childDirectories = directory.GetDirectories();
            foreach (DirectoryInfo dir in childDirectories)
            {
                TraverseDirectory(dir, db);
            }

            FileInfo[] files = directory.GetFiles();
            foreach (var file in files)
            {
                DataTable data = ReadFile(file.FullName);
                SalesReport report = new SalesReport();

                foreach (DataRow row in data.Rows)
                {
                    Sale sale = CreateSale(row, db);
                    db.Sales.Add(sale);
                    sale.SalesReport = report;
                    sale.SalesReportId = report.Id;
                    report.Sales.Add(sale);
                }

                db.SalesReports.Add(report);
                db.SaveChanges();
            }
        }

        private static DataTable ReadFile(string path)
        {
            using (var connection = new OleDbConnection())
            {
                var dataTable = new DataTable();
                string fileExtension = Path.GetExtension(path);
                connection.ConnectionString = string.Format(OleDbConnectionString, path);

                using (var command = new OleDbCommand())
                {
                    command.CommandText = string.Format(SelectQuery);
                    command.Connection = connection;

                    using (var dataAdapter = new OleDbDataAdapter())
                    {
                        dataAdapter.SelectCommand = command;
                        dataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        private static Sale CreateSale(DataRow row, ISqlServerDb db)
        {
            string str = row["ShopId"].ToString();
            var shopId = Guid.Parse(row["ShopId"].ToString());
            var shop = db.Shops.All().FirstOrDefault(s => s.Id == shopId);

            var productId = Guid.Parse(row["ProductId"].ToString());
            var product = db.MobileDevices.All().FirstOrDefault(d => d.Id == productId);

            var employeeId = Guid.Parse(row["ResponsibleEmploeeId"].ToString());
            var employee = db.Employees.All().FirstOrDefault(e => e.Id == employeeId);

            var saleDate = DateTime.Parse(row["DateTime"].ToString());
            var quantity = int.Parse(row["Quantity"].ToString());
            var totalValue = int.Parse(row["TotalValue"].ToString());
            var currency = (CurrencyType)Enum.Parse(typeof(CurrencyType), row["Currency"].ToString());

            var sale = new Sale
            {
                ShopId = shopId,
                Shop = shop,
                ProductId = productId,
                Product = product,
                EmployeeId = employeeId,
                Employee = employee,
                SaleDate = saleDate,
                Quantity = quantity,
                TotalValue = totalValue,
                Currency = currency
            };

            return sale;
        }

        private static Shop CreateShop(Guid id, string name)
        {
            var shop = new Shop
            {
                Id = id,
                Name = name
            };

            return shop;
        }

        private static void ValidateIfObjectIsNull(object objToValidate, string errorMessage)
        {
            if (objToValidate == null)
            {
                throw new ArgumentNullException(errorMessage);
            }
        }
    }
}