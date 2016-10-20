using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using MobiStore.Models.MobileDevices;

namespace MobiStore.Models
{
    [XmlRoot("shop")]
    public class Shop
    {
        public Shop()
        {
            this.Id = Guid.NewGuid();
        }

        [XmlIgnore]
        public Guid Id { get; set; }

        [XmlIgnore]
        public string Name { get; set; }

        [XmlElement("mobile-device")]
        public List<MobileDevice> MobileDevices { get; set; }
    }
}