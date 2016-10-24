using System.Collections.Generic;

using MobiStore.MySqlDatabase.Models;

using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Metadata.Fluent;

namespace MobiStore.MySqlDatabase
{
    public class MySqlModelsConfig : FluentMetadataSource
    {
        protected override IList<MappingConfiguration> PrepareMapping()
        {
            var configs = new List<MappingConfiguration>();
            var salesMapping = new MappingConfiguration<SalesReport>();

            salesMapping.HasProperty(s => s.Id).IsIdentity(KeyGenerator.Autoinc);
            salesMapping.MapType(report => new
            {
                Employee = report.Employee,
                Product = report.Product,
                Shop = report.Shop,
                Date = report.Date,
                TotalValue = report.TotalValue
            }).ToTable("sales_reports");

            configs.Add(salesMapping);
            return configs;
        }
    }
}