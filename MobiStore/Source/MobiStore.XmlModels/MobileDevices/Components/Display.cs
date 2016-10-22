using System;
using System.Xml.Serialization;

using MobiStore.Models.Enumerations;

namespace MobiStore.XmlModels.MobileDevices.Components
{
    public class Display
    {
        [XmlIgnore]
        public DisplayType Type { get; set; }

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
                    this.Type = default(DisplayType);
                }
                else
                {
                    this.Type = (DisplayType)Enum.Parse(typeof(DisplayType), value);
                }
            }
        }

        [XmlElement("size")]
        public double Size { get; set; }

        [XmlElement("resolution")]
        public string Resolution { get; set; }
    }
}
