using System.ComponentModel.DataAnnotations;

namespace EnergyTrackerProject.Models
{
    public class EnergyUsage
    {
        [Key]
        public int UsageId { get; set; }

        public int DeviceId { get; set; }

        public decimal HoursUsed { get; set; }

        public DateTime Date { get; set; }

        public decimal EnergyConsumed { get; set; }

        public decimal Cost { get; set; }

        public Device ? Device { get; set; }
    }
}