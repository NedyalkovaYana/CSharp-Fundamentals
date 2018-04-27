public class PressureProvider : Provider
{
    private const double PercentageEnergyOutputIncreasement = 1.5;

    public PressureProvider(string id, double energyOutput) 
        : base(id, energyOutput)
    {
    }

    private static double IncreasedEnergy(double energyOutput) => energyOutput * PercentageEnergyOutputIncreasement;
}

