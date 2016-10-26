using System;
using System.ComponentModel.DataAnnotations;
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

        [MaxLength(20)]
        [MinLength(2)]
        [Required]
        public string Model { get; set; }

        [Required]
        public Brand Brand { get; set; }

        public Guid? BatteryId { get; set; }

        public Guid? DisplayId { get; set; }

        public Guid? ProcessorId { get; set; }
        
        public virtual Battery Battery { get; set; }
        
        public virtual Display Display { get; set; }
        
        public virtual Processor Processor { get; set; }
    }
}