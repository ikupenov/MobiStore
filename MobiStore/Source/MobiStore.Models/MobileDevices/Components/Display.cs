using System;
using System.Collections.Generic;

using MobiStore.Models.Common;
using MobiStore.Models.Enumerations;

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

        public DisplayType Type { get; set; }

        public int Size { get; set; }

        public string Resolution { get; set; }

        public Guid? CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<MobileDevice> MobileDevices
        {
            get { return this.mobileDevices; }

            set { this.mobileDevices = value; }
        }
    }
}
