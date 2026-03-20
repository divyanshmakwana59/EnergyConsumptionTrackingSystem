namespace EnergyTrackerProject.Helpers
{
    public static class CalculationHelper
    {
        public static double CalculateEnergy(int watts, double hours)
        {
            return (watts * hours) / 1000;
        }
    }
}