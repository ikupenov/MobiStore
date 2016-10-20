using MobiStore.Data.Contracts;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using MobiStore.Models.Enumerations;
using System;

namespace MobiStore.Utils.Exporters
{
    public static class JsonReporter
    {
        public static void CreateReports(IMobiStoreData db, DirectoryInfo jsonDirectory)
        {
            var allReports = db
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
                string fileName = $"{jsonDirectory}\\{report.Id}.json";
                var jsonObject = JsonConvert.SerializeObject(report);

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine(jsonObject);
                }
            }
        }
    }
}