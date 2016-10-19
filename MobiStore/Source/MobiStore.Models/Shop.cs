using System;

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
    }
}