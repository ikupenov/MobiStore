using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        public BatteryType Type { get; set; }

        [Required]
        public int Capacity { get; set; }
        
        [BsonIgnore]
        public virtual ICollection<MobileDevice> MobileDevices
        {
            get { return this.mobileDevices; }

            set { this.mobileDevices = value; }
        }
    }
}
