using System.Linq;

using MobiStore.Data.Contracts;
using MobiStore.MySqlDatabase.Models;

namespace MobiStore.MySqlDatabase
{
    public class MySqlSeeder
    {
        public static void SeedDatabase(ISqlServerDb sqlServerDatabase, MySqlDb databaseToSeed)
        {
            var allReports = sqlServerDatabase
               .SalesReports
               .All()
               .Select(r => r.Sales.Select(s => new SalesReport()
               {
                   Employee = s.Employee.Name,
                   Product = s.Product.Model,
                   Shop = s.Shop.Name,
                   Date = s.SaleDate,
                   TotalValue = s.TotalValue
               }))
               .SelectMany(x => x)
               .ToList();

            databaseToSeed.SalesRepository.AddMany(allReports);
            databaseToSeed.SalesRepository.SaveChanges();
        }
    }
}