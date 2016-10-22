using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MobiStore.XmlModels.Reporters
{
    [XmlRoot("sales-report")]
    public class SalesReport
    {
        private List<Sale> sales;

        public SalesReport()
        {
            this.Id = Guid.NewGuid();
            this.sales = new List<Sale>();
        }

        [XmlElement("id")]
        public Guid Id { get; set; }

        [XmlElement("sales")]
        public virtual List<Sale> Sales
        {
            get { return this.sales; }

            set { this.sales = value; }
        }
    }
}