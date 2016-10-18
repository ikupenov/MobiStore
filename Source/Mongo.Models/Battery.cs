using Mongo.Models.Enumerations;

namespace Mongo.Models
{
    public class Battery
    {
        public int Capacity { get; set; }

        public BatteryType Type { get; set; }
    }
}