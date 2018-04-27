public class HeavyHardware : Hardware
{
    public HeavyHardware(string name, int maxCapacity, int maxMemory) 
        : base(name, "Heavy", maxCapacity, maxMemory)
    {
        this.MaxMemory -= (maxMemory * 25) / 100;
        this.MaxCapacity *= 2;
    }
}

