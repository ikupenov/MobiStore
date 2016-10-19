using System;
using System.Collections.Generic;

namespace MobiStore.Models.Reports
{
    public class SalesReport
    {
        private ICollection<Sale> sales;

        public SalesReport()
        {
            this.Id = Guid.NewGuid();
            this.sales = new HashSet<Sale>();
        }

        public Guid Id { get; set; }

        public virtual ICollection<Sale> Sales
        {
            get { return this.sales; }

            set { this.sales = value; }
        }
    }
}