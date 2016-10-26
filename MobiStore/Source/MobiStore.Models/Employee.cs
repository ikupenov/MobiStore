using System;
using System.ComponentModel.DataAnnotations;

namespace MobiStore.Models
{
    public class Employee
    {
        public Employee()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}