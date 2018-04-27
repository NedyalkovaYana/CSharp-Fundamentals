public class PowerHardware : Hardware
{
    public PowerHardware(string name, int maxCapacity, int maxMemory) 
        : base(name, "Power", maxCapacity, maxMemory)
    {
        this.MaxCapacity -= (maxCapacity * 75)/100;
        this.MaxMemory += (maxCapacity * 75) / 100;
    }
}

