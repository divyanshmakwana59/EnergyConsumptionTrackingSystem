using System.ComponentModel.DataAnnotations;

namespace EnergyTrackerProject.Models
{
    public class Device
    {
        [Key]
        public int DeviceId { get; set; }

        public string DeviceName { get; set; } = "";

        public int PowerRating { get; set; }
    }
}