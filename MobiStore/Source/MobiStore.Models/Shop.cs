using System;
using System.Collections.Generic;
using System.Xml.Serialization;

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

        public string Name { get; set; }

        public List<MobileDevice> MobileDevices { get; set; }
    }
}