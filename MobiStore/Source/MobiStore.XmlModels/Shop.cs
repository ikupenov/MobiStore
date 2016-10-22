using System.Collections.Generic;
using System.Xml.Serialization;

using MobiStore.XmlModels.MobileDevices;

namespace MobiStore.XmlModels
{
    [XmlRoot("shop")]
    public class Shop
    {
        [XmlElement("mobile-device")]
        public List<MobileDevice> MobileDevices { get; set; }
    }
}