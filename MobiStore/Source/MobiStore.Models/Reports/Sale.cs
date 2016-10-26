using System;
using System.ComponentModel.DataAnnotations.Schema;

using MobiStore.Models.Enumerations;
using MobiStore.Models.MobileDevices;
using System.ComponentModel.DataAnnotations;

namespace MobiStore.Models.Reports
{
    public class Sale
    {
        public Sale()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public CurrencyType Currency { get; set; }

        [Required]
        public int TotalValue { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime SaleDate { get; set; }

        public Guid? ShopId { get; set; }

        public Guid? ProductId { get; set; }

        public Guid? EmployeeId { get; set; }

        public Guid? SalesReportId { get; set; }

        public virtual Shop Shop { get; set; }

        public virtual MobileDevice Product { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual SalesReport SalesReport { get; set; }
    }
}