
using System;

public  class HardwareFactory
{

    public Hardware CreateHardware(string type, string name, int capacity, int memory)
    {
        switch (type)
        {
            case "Power":    
                return new PowerHardware(name, capacity, memory);
            case "Heavy":
                return new HeavyHardware(name, capacity, memory);
                default:
                throw new ArgumentException();
        }
    }
}

