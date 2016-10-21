using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

using MobiStore.Models.Common;
using MobiStore.Models.Contracts;
using MobiStore.Models.Enumerations;
using MobiStore.Models.MobileDevices.Components;

namespace MobiStore.Models.MobileDevices
{
    public class MobileDevice : ICountryManufacturer
    {
        public MobileDevice()
        {
            this.Id = Guid.NewGuid();
        }

        [XmlIgnore]
        public Guid Id { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlIgnore]
        public Brand Brand { get; set; }

        [XmlElement("brand")]
        [NotMapped]
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

        [XmlIgnore]
        public Guid? CountryId { get; set; }

        [XmlIgnore]
        public Guid? BatteryId { get; set; }

        [XmlIgnore]
        public Guid? DisplayId { get; set; }

        [XmlIgnore]
        public Guid? ProcessorId { get; set; }

        [XmlIgnore]
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [XmlElement("battery")]
        [ForeignKey("BatteryId")]
        public virtual Battery Battery { get; set; }

        [XmlElement("display")]
        [ForeignKey("DisplayId")]
        public virtual Display Display { get; set; }

        [XmlElement("processor")]
        [ForeignKey("ProcessorId")]
        public virtual Processor Processor { get; set; }
    }
}