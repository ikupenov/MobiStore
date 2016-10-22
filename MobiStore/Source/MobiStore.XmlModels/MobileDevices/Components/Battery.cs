using System;
using System.Xml.Serialization;

using MobiStore.Models.Enumerations;

namespace MobiStore.XmlModels.MobileDevices.Components
{
    public class Battery
    {
        [XmlIgnore]
        public BatteryType Type { get; set; }

        [XmlElement("type")]
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
    }
}
