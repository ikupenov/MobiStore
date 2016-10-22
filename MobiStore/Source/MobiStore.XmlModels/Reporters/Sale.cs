using System;
using System.Xml.Serialization;

namespace MobiStore.XmlModels.Reporters
{
    public class Sale
    {
        public Sale()
        {
            this.Id = Guid.NewGuid();
        }

        [XmlAttribute("id")]
        public Guid Id { get; set; }

        [XmlElement("total-value")]
        public int TotalValue { get; set; }

        [XmlElement("sale-date")]
        public DateTime SaleDate { get; set; }

        [XmlElement("shop-name")]
        public string Shop { get; set; }

        [XmlElement("employee")]
        public string Employee { get; set; }
    }
}