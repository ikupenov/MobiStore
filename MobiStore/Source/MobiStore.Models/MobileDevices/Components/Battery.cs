using System;
using System.Collections.Generic;

using MobiStore.Models.Common;
using MobiStore.Models.Contracts;
using MobiStore.Models.Enumerations;

namespace MobiStore.Models.MobileDevices.Components
{
    public class Battery : ICountryManufacturer
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

        public Guid? CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<MobileDevice> MobileDevices
        {
            get { return this.mobileDevices; }

            set { this.mobileDevices = value; }
        }
    }
}
