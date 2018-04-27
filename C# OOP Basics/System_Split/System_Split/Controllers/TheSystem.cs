using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

public class TheSystem
{
    private List<Hardware> system;
    private int MaxCapacity;
    private int MaxMemory;
    private int totalOperationalMemoryInUse;
    private int totalCapacityTaken;

    public TheSystem()
    {
        this.system = new List<Hardware>();
    }

    public void AddHardware(Hardware hardware)
    {
        this.system.Add(hardware);
        this.MaxCapacity += hardware.MaxCapacity;
        this.MaxMemory += hardware.MaxMemory;
    }

    public void AddSoftware(string hardwareName, Software software)
    {
        try
        {
            var hardName = system.FirstOrDefault(k => k.Name == hardwareName);
            if (hardName != null)
            {               
                hardName.ReduceHardwareMemoryAndCapacity
                (software.CapacityConsumption, software.MemoryConsumption);
                hardName.AddSoftwareComponents(software);
            }
        }
        catch (ArgumentException) { }
    }

    public void DestroySoftwareComponent(string hardwareComponentName, string softwareComponentName)
    {
        var findedHardware = system.FirstOrDefault(k => k.Name == hardwareComponentName);
        var findedSoftware = findedHardware.IsSoftwareExists(softwareComponentName);

        if (findedHardware != null && findedSoftware == true)
        {
          
            findedHardware.DeleteSoftwareComponent(softwareComponentName);
        }
    }

    public string SystemSplit()
    {
        var sb = new StringBuilder();

        foreach (var hardware in system)
        {
            sb.AppendLine($"Hardware Component - {hardware.Name}")
                .AppendLine($"Express Software Components: {hardware.GetSoftwareExpressComponents()}")
                .AppendLine($"Light Software Components: {hardware.GetSoftwareLightComponents()}")
                .AppendLine($"Memory Usage: {hardware.GetTotalMemoryInUse()} / {hardware.MaxMemory}")
                .AppendLine($"Capacity Usage: {hardware.GetTotalCapacityTaken()} / {hardware.MaxCapacity}")
                .AppendLine($"Type: {hardware.Type}");
            var softwareComponentsCount = hardware.GetSoftwareComponentsCount();
            if (softwareComponentsCount == 0)
            {
                sb.AppendLine($"Software Components: None");
            }
            else
            {
                var names = hardware.GetSoftwareComponentsName();
                sb.AppendLine($"Software Components: {string.Join(", ", names)}");
            }
        }

        return sb.ToString().Trim();
    }

    public override string ToString()
    {
        var softwareComponentsCount = 0;

        foreach (var element in system)
        {
            softwareComponentsCount += element.GetSoftwareComponentsCount();
            totalOperationalMemoryInUse += element.TotalOperationalMemoryInUse();
            totalCapacityTaken += element.GetTotalCapacityTaken();
        }

        var sb = new StringBuilder();

        sb.AppendLine("System Analysis")
            .AppendLine($"Hardware Components: {system.Count}")
            .AppendLine($"Software Components: {softwareComponentsCount}")
            .AppendLine($"Total Operational Memory: {totalOperationalMemoryInUse} / {MaxMemory}")
            .AppendLine($"Total Capacity Taken: {totalCapacityTaken} / {MaxCapacity}");

        return sb.ToString().Trim();
    }
}

