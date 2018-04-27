using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Hardware : IUnits
{
    private int maxCapacity;
    private int maxMemory;
    private List<Software> softwareComponents;
    protected Hardware(string name, string type, int maxCapacity, int maxMemory)
    {      
        this.Name = name;
        this.Type = type;
        this.MaxCapacity = maxCapacity;
        this.MaxMemory = maxMemory;
        this.softwareComponents = new List<Software>();
    }
    
    public int MaxCapacity
    {
        get { return this.maxCapacity; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            this.maxCapacity = value;
        }
    }
    public int MaxMemory
    {
        get { return this.maxMemory; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            this.maxMemory = value;
        }
    }
    public string Name { get; }
    public string Type { get; }

    public void AddSoftwareComponents(Software software)
    {
        this.softwareComponents.Add(software);
    }

    public void DeleteSoftwareComponent(string softName)
    {
        var findedSoftware = softwareComponents.FirstOrDefault(f => f.Name == softName);
        if (findedSoftware != null)
        {
            softwareComponents.Remove(findedSoftware);
        }
    }

    public bool IsSoftwareExists(string softwareName)
    {
        var result =  this.softwareComponents.FirstOrDefault(s => s.Name == softwareName);
        if (result != null)
        {
            return true;
        }

        return false;
    }
    public void ReduceHardwareMemoryAndCapacity(int capacity, int memory)
    {
        this.MaxCapacity -= capacity;
        this.MaxMemory -= memory;
    }

    public int GetSoftwareComponentsCount()
    {
        return softwareComponents.Count;
    }

    public int TotalOperationalMemoryInUse()
    {
        int total = 0;
        foreach (var software in softwareComponents)
        {
            total += software.MemoryConsumption;
        }

        return total;
    }

    public int  GetTotalCapacityTaken()
    {
        int capacity = 0;
        foreach (var software in softwareComponents)
        {
            capacity += software.CapacityConsumption;
        }

        return capacity;
    }

    public List<string> GetSoftwareComponentsName()
    {
        var names = new List<string>();

        foreach (var soft in softwareComponents)
        {
            names.Add(soft.Name);
        }

        return names;
    }

    public int GetTotalMemoryInUse()
    {
        var total = 0;
        foreach (var soft in softwareComponents)
        {
            total += soft.MemoryConsumption;
        }

        return total;
    }
  
    public int GetSoftwareExpressComponents()
    {
        int total = 0;

        foreach (var soft in softwareComponents)
        {
            if (soft.Type == "Express")
            {
                total++;
            }        
        }

        return total;
    }

    public int GetSoftwareLightComponents()
    {
        int total = 0;

        foreach (var soft in softwareComponents)
        {
            if (soft.Type == "Light")
            {
                total++;
            }
        }

        return total;
    }
}

