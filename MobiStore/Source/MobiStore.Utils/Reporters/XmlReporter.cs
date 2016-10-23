using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

using MobiStore.Data.Contracts;
using MobiStore.XmlModels.Reporters;

namespace MobiStore.Utilities.Reporters
{
    public class XmlReporter
    {
        public static void CreateReports(ISqlServerDb sqlServerDatabase, XmlSerializer xmlSerializer, DirectoryInfo destinationDirectory)
        {
            var allReports = sqlServerDatabase
                .SalesReports
                .All()
                .Select(r => new SalesReport()
                {
                    Id = r.Id,
                    Sales = r.Sales.Select(s => new Sale()
                    {
                        Id = s.Id,
                        Employee = s.Employee.Name,
                        SaleDate = s.SaleDate,
                        Shop = s.Shop.Name,
                        TotalValue = s.TotalValue
                    })
                    .ToList()
                })
                .ToList();

            var xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;

            foreach (var report in allReports)
            {
                string fileName = $"{destinationDirectory}\\{report.Id}.xml";

                using (var writer = XmlWriter.Create(fileName, xmlWriterSettings))
                {
                    xmlSerializer.Serialize(writer, report);
                }
            }
        }
    }
}