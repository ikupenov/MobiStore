using System;
using System.Collections.Generic;

using MobiStore.Models.Enumerations;
using MongoDB.Bson.Serialization.Attributes;

namespace MobiStore.Models.MobileDevices.Components
{
    public class Battery 
    {
        private ICollection<MobileDevice> mobileDevices;

        public Battery()
        {
            this.Id = Guid.NewGuid();
            this.mobileDevices = new HashSet<MobileDevice>();
        }

        public Guid Id { get; set; }

        public BatteryType Type { get; set; }

        public int Capacity { get; set; }
        
        [BsonIgnore]
        public virtual ICollection<MobileDevice> MobileDevices
        {
            get { return this.mobileDevices; }

            set { this.mobileDevices = value; }
        }
    }
}
