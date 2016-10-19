using System;

namespace MobiStore.Models
{
    public class Employee
    {
        public Employee()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}