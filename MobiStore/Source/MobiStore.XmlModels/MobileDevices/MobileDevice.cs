using System;
using System.Xml.Serialization;

using MobiStore.Models.Enumerations;
using MobiStore.XmlModels.MobileDevices.Components;

namespace MobiStore.XmlModels.MobileDevices
{
    public class MobileDevice
    {
        [XmlElement("model")]
        public string Model { get; set; }

        [XmlIgnore]
        public Brand Brand { get; set; }

        [XmlElement("brand")]
        public string BrandAsString
        {
            get
            {
                return this.Brand.ToString();
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.Brand = default(Brand);
                }
                else
                {
                    this.Brand = (Brand)Enum.Parse(typeof(Brand), value);
                }
            }
        }

        [XmlElement("battery")]
        public virtual Battery Battery { get; set; }

        [XmlElement("display")]
        public virtual Display Display { get; set; }

        [XmlElement("processor")]
        public virtual Processor Processor { get; set; }
    }
}