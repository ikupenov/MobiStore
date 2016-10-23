using System.ComponentModel.DataAnnotations;

namespace MobiStore.SqliteDatabase.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Town { get; set; }
    }
}