using Mongo.Models.Enumerations;

namespace Mongo.Models
{
    public class Display
    {
        public DisplayType Type { get; set; }

        public int Size { get; set; }

        public string Resolution { get; set; }
    }
}