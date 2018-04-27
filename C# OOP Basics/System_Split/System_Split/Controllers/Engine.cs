using System;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;

public class Engine
{
    private Manager manager;
  

    public Engine(Manager manager)
    {
        this.manager = new Manager();       
    }

    public void Run()
    { 
        var input = string.Empty;

        while ((input = Console.ReadLine()) != "System Split")
        {
            var line = input.Split(new[] {',', ' ', '(', ')'}, StringSplitOptions.RemoveEmptyEntries);
            var command = line[0];         
            string name;
            int capacity;
            int memory;
            string hardwareComponentName;
            switch (command)
            {
                case "RegisterPowerHardware":
                    name = line[1];
                    capacity = int.Parse(line[2]);
                    memory = int.Parse(line[3]);
                    manager.RegisterPowerHardware(name, capacity, memory);
                    break;
                case "RegisterHeavyHardware":
                    name = line[1];
                    capacity = int.Parse(line[2]);
                    memory = int.Parse(line[3]);
                    manager.RegisterHeavyHardware(name, capacity, memory);
                    break;
                case "RegisterExpressSoftware":
                    hardwareComponentName = line[1];
                    name = line[2];
                    capacity = int.Parse(line[3]);
                    memory = int.Parse(line[4]);
                    manager.RegisterExpressSoftware(hardwareComponentName, name, capacity, memory);
                    break;

                case "RegisterLightSoftware":
                    hardwareComponentName = line[1];
                    name = line[2];
                    capacity = int.Parse(line[3]);
                    memory = int.Parse(line[4]);
                    manager.RegisterLightSoftware(hardwareComponentName, name, capacity, memory);
                    break;
                case "ReleaseSoftwareComponent":
                    var hardwareName = line[1];
                    var softwareName = line[2];
                    manager.ReleaseSoftwareComponent(hardwareName, softwareName);
                    break;
                case "Analyze":
                    Console.WriteLine(manager.Analyze());
                    break;

            }
        }

        Console.WriteLine(manager.SystemSplit());
    }
}

