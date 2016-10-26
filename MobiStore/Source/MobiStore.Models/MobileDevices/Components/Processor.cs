using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using MongoDB.Bson.Serialization.Attributes;

namespace MobiStore.Models.MobileDevices.Components
{
    public class Processor
    {
        private ICollection<MobileDevice> mobileDevices;

        public Processor()
        {
            this.Id = Guid.NewGuid();
            this.mobileDevices = new HashSet<MobileDevice>();
        }

        public Guid Id { get; set; }

        [Required]
        public double ClockSpeed { get; set; }

        [Required]
        public double CacheMemory { get; set; }
        
        [BsonIgnore]
        public virtual ICollection<MobileDevice> MobileDevices
        {
            get { return this.mobileDevices; }

            set { this.mobileDevices = value; }
        }
    }
}