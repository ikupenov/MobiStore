using System;
using System.Collections.Generic;

using MobiStore.Models.Enumerations;
using MongoDB.Bson.Serialization.Attributes;

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

        public Guid Id { get; set; }

        public DisplayType Type { get; set; }

        public double Size { get; set; }

        public string Resolution { get; set; }
        
        [BsonIgnore]
        public virtual ICollection<MobileDevice> MobileDevices
        {
            get { return this.mobileDevices; }

            set { this.mobileDevices = value; }
        }
    }
}
