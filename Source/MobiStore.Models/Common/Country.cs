using System;
using System.Collections.Generic;

using MobiStore.Models.MobileDevices;

namespace MobiStore.Models.Common
{
    public class Country
    {
        private ICollection<MobileDevice> mobileDevices;

        public Country()
        {
            this.Id = Guid.NewGuid();
            this.mobileDevices = new HashSet<MobileDevice>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<MobileDevice> MobileDevices
        {
            get { return this.mobileDevices; }

            set { this.mobileDevices = value; }
        }
    }
}