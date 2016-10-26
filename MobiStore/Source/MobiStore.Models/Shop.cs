using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using MobiStore.Models.MobileDevices;

namespace MobiStore.Models
{
    public class Shop
    {
        public Shop()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public List<MobileDevice> MobileDevices { get; set; }
    }
}