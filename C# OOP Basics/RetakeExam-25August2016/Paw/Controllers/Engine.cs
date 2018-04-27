using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;

public class Engine
{
    private Manager manager;
    private bool isRunning;

    public Engine()
    {
        this.manager = new Manager();
        isRunning = true;
    }

    
    public void Run()
    {
        while (this.isRunning)
        {
           var inputLines = Console.ReadLine()
                .Split(new string[] {" | "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var command = inputLines[0];

            switch (command)
            {
                case "RegisterCastrationCenter":
                    manager.RegisterCastractionCenter(inputLines);
                    break;
                case "RegisterAdoptionCenter":
                    manager.RegisterAdoptionCenter(inputLines);
                    break;
                case "RegisterCleansingCenter":
                    manager.RegisterCleansingCenter(inputLines);
                    break;
                case "RegisterDog":
                    manager.RegisterDog(inputLines);
                    break;
                case "RegisterCat":
                    manager.RegisterCat(inputLines);
                    break;
                case "SendForCleansing":
                    manager.SendForCleansing(inputLines);
                    break;
                case "SendForCastration":
                 manager.SendForCastration(inputLines);
                    break;
                case "Castrate":
                    manager.Castrate(inputLines);
                    break;
                case "Cleanse":
                    manager.Cleanse(inputLines);
                    break;
                case "Adopt":
                    manager.Adopt(inputLines);
                    break;
                case "CastrationStatistics":
                    Console.WriteLine(manager.CastrationStatistics(inputLines));
                    break;
                case "Paw Paw Pawah":
                    Console.WriteLine(manager.PawPaw());
                    isRunning = false;
                    break;
            }

        }
    }
}

