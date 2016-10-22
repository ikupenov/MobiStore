using System.Xml.Serialization;

namespace MobiStore.XmlModels.MobileDevices.Components
{
    public class Processor
    {
        [XmlElement("clock-speed")]
        public double ClockSpeed { get; set; }

        [XmlElement("cache-memory")]
        public double CacheMemory { get; set; }
    }
}