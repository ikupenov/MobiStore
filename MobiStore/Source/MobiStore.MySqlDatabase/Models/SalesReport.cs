using System;

namespace MobiStore.MySqlDatabase.Models
{
    public class SalesReport
    {
        public int Id { get; set; }

        public string Employee { get; set; }

        public string Product { get; set; }

        public string Shop { get; set; }

        public DateTime Date { get; set; }

        public int TotalValue { get; set; }
    }
}