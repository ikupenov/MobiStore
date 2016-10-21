using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using MobiStore.Models.Common;
using MobiStore.Models.Contracts;

namespace MobiStore.Models.MobileDevices.Components
{
    public class Processor : ICountryManufacturer
    {
        private ICollection<MobileDevice> mobileDevices;

        public Processor()
        {
            this.Id = Guid.NewGuid();
            this.mobileDevices = new HashSet<MobileDevice>();
        }

        [XmlIgnore]
        public Guid Id { get; set; }

        [XmlElement("clock-speed")]
        public double ClockSpeed { get; set; }

        [XmlElement("cache-memory")]
        public double CacheMemory { get; set; }

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