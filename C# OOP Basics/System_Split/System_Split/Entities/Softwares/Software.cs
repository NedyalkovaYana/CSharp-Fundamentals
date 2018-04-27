public abstract class Software : IUnits
{
    protected Software(string name, string type, int capacityConsumption, int memoryConsumption)
    {
        this.Name = name;
        this.Type = type;
        this.CapacityConsumption = capacityConsumption;
        this.MemoryConsumption = memoryConsumption;
    }
    public string Name { get; }
    public string Type { get; }
    public int CapacityConsumption { get; protected set; }
    public int MemoryConsumption { get; protected set; }
}

