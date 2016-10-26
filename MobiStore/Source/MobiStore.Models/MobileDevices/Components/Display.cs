using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        public DisplayType Type { get; set; }

        [Required]
        public double Size { get; set; }

        [Required]
        public string Resolution { get; set; }
        
        [BsonIgnore]
        public virtual ICollection<MobileDevice> MobileDevices
        {
            get { return this.mobileDevices; }

            set { this.mobileDevices = value; }
        }
    }
}
