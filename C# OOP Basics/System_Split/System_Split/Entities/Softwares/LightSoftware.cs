public class LightSoftware : Software
{
    public LightSoftware(string name, int capacityConsumption, int memoryConsumption) 
        : base(name, "Light", capacityConsumption, memoryConsumption)
    {
        this.CapacityConsumption += (capacityConsumption * 50) / 100;
        this.MemoryConsumption -= (memoryConsumption * 50) / 100;
    }
}

