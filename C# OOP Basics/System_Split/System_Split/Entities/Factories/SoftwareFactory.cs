
using System;

public class SoftwareFactory
{
    public Software CreateSoftware(string type, string name, int capacity, int memory)
    {
        switch (type)
        {
            case "Express":
                return  new ExpressSoftware(name, capacity, memory);
            case "Light":
                return new LightSoftware(name, capacity, memory);
                default:
                    throw new ArgumentException();
        }
    }
}


