using System.IO;
using System.Linq;

using MobiStore.Data.Contracts;
using MobiStore.Models.Enumerations;

using Newtonsoft.Json;

namespace MobiStore.Utils.Exporters
{
    public class XmlReporter
    {
        public static void CreateReports(IMobiStoreData sqlServerDatabase, DirectoryInfo destinationDirectory)
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
                    }).ToList()
                }).ToList();

            foreach (var report in allReports)
            {
                string fileName = $"{destinationDirectory}\\{report.Id}.xml";
                var jsonObject = JsonConvert.SerializeObject(report);
                var xmlDoc = JsonConvert.DeserializeXmlNode(jsonObject, "SalesReport");

                xmlDoc.Save(fileName);
            }
        }
    }
}