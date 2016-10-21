using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

using MobiStore.Models.Common;
using MobiStore.Models.Contracts;
using MobiStore.Models.Enumerations;

namespace MobiStore.Models.MobileDevices.Components
{
    public class Battery : ICountryManufacturer
    {
        private ICollection<MobileDevice> mobileDevices;

        public Battery()
        {
            this.Id = Guid.NewGuid();
            this.mobileDevices = new HashSet<MobileDevice>();
        }

        [XmlIgnore]
        public Guid Id { get; set; }

        [XmlIgnore]
        public BatteryType Type { get; set; }

        [XmlElement("type")]
        [NotMapped]
        public string TypeAsString
        {
            get
            {
                return this.Type.ToString();
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.Type = default(BatteryType);
                }
                else
                {
                    this.Type = (BatteryType)Enum.Parse(typeof(BatteryType), value);
                }
            }
        }

        [XmlElement("capacity")]
        public int Capacity { get; set; }

        [XmlIgnore]
        public Guid? CountryId { get; set; }

        [XmlIgnore]
        public virtual Country Country { get; set; }

        [XmlIgnore]
        public virtual ICollection<MobileDevice> MobileDevices
        {
            get { return this.mobileDevices; }

            set { this.mobileDevices = value; }
        }
    }
}
