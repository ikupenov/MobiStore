﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

using MobiStore.Models.Common;
using MobiStore.Models.Enumerations;

namespace MobiStore.Models.MobileDevices.Components
{
    public class Display
    {
        private ICollection<MobileDevice> mobileDevices;

        public Display()
        {
            this.Id = Guid.NewGuid();
            this.mobileDevices = new HashSet<MobileDevice>();
        }

        [XmlIgnore]
        public Guid Id { get; set; }

        [XmlIgnore]
        public DisplayType Type { get; set; }

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
