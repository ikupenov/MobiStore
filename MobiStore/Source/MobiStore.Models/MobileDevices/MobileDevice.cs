using System;
using System.ComponentModel.DataAnnotations.Schema;

using MobiStore.Models.Enumerations;
using MobiStore.Models.MobileDevices.Components;

namespace MobiStore.Models.MobileDevices
{
    public class MobileDevice 
    {
        public MobileDevice()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Model { get; set; }

        public Brand Brand { get; set; }
        
        public Guid? BatteryId { get; set; }

        public Guid? DisplayId { get; set; }

        public Guid? ProcessorId { get; set; }
        
        [ForeignKey("BatteryId")]
        public virtual Battery Battery { get; set; }

        [ForeignKey("DisplayId")]
        public virtual Display Display { get; set; }

        [ForeignKey("ProcessorId")]
        public virtual Processor Processor { get; set; }
    }
}