using System.ComponentModel.DataAnnotations;

namespace EnergyTrackerProject.Models
{
    public class EnergyConsumption
    {
        [Key] public int Id { get; set; }

        //[Required]
        public DateTime Date { get; set; }

        public double UnitsConsumed { get; set; }

        public double CostPerUnit { get; set; }

        public double TotalCost { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}