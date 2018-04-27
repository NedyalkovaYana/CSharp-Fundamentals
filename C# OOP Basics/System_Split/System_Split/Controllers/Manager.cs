using System.Collections.Generic;

public  class Manager
{
    private SoftwareFactory createSoftware;
    private HardwareFactory createHardware;
    private TheSystem system;

    public Manager()
    {
        this.createSoftware = new SoftwareFactory();
        this.createHardware = new HardwareFactory();
        this.system = new TheSystem();
    }

    public void RegisterPowerHardware(string name, int capacity, int memory)
    {
        system.AddHardware(createHardware.CreateHardware("Power", name, capacity, memory));
    }

    public void RegisterHeavyHardware(string name, int capacity, int memory)
    {
        system.AddHardware(createHardware.CreateHardware("Heavy", name, capacity, memory));
    }

    public void RegisterExpressSoftware(string hardwareComponentName, string name, int capacity, int memory)
    {
        system.AddSoftware(hardwareComponentName, createSoftware.CreateSoftware("Express", name, capacity, memory));
    }

    public void RegisterLightSoftware(string hardwareComponentName, string name, int capacity,int memory)
    {
        system.AddSoftware(hardwareComponentName, createSoftware.CreateSoftware("Light", name, capacity, memory));
    }

    public void ReleaseSoftwareComponent(string hardwareComponentName, string softwareComponentName)
    {
        system.DestroySoftwareComponent(hardwareComponentName, softwareComponentName);
    }

    public string Analyze()
    {
        return system.ToString();
    }

    public string SystemSplit()
    {
        return system.SystemSplit();
    }
}

