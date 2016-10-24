﻿using System;
using System.Collections.Generic;

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

        public double ClockSpeed { get; set; }

        public double CacheMemory { get; set; }
        
        [BsonIgnore]
        public virtual ICollection<MobileDevice> MobileDevices
        {
            get { return this.mobileDevices; }

            set { this.mobileDevices = value; }
        }
    }
}