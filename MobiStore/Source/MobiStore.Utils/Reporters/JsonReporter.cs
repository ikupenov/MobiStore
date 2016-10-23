using System.IO;
using System.Linq;

using MobiStore.Data.Contracts;
using MobiStore.Models.Enumerations;

using Newtonsoft.Json;

namespace MobiStore.Utilities.Reporters
{
    public class JsonReporter
    {
        public static void CreateReports(ISqlServerDb sqlServerDatabase, DirectoryInfo destinationDirectory)
        {
            var allReports = sqlServerDatabase
                .SalesReports
                .All()
                .Select(r => new
                {
                    Id = r.Id,
                    Sales = r.Sales.Select(s => new
                    {
                        Employee = s.Employee.Name,
                        SaleDate = s.SaleDate,
                        ShopName = s.Shop.Name,
                        Product = (Brand)s.Product.Brand,
                        TotalValue = s.TotalValue
                    })
                    .ToList()
                })
                .ToList();

            foreach (var report in allReports)
            {
                string fileName = $"{destinationDirectory}\\{report.Id}.json";
                var jsonObject = JsonConvert.SerializeObject(report);

                using (var writer = new StreamWriter(fileName))
                {
                    writer.WriteLine(jsonObject);
                }
            }
        }
    }
}