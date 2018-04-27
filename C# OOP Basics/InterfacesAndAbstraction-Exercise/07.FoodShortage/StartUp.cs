using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        List<IByer> townPopulation = GetPopulationInfo();
        PrintFood(townPopulation);
    }

    private static void PrintFood(List<IByer> townPopulation)
    {
        var inputNames = string.Empty;
        while ((inputNames = Console.ReadLine()) != "End")
        {
            var existName = townPopulation.FirstOrDefault(n => n.Name == inputNames);
            if (existName != null)
            {
                existName.BuyFood();
            }
        }

        var totalFood = townPopulation.Sum(a => a.Food);

        Console.WriteLine(totalFood);
    }

    private static List<IByer> GetPopulationInfo()
    {
        var numberOfInputs = int.Parse(Console.ReadLine());
        List<IByer> townPopulation = new List<IByer>();

        for (int i = 0; i < numberOfInputs; i++)
        {
            var inputInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (inputInfo.Length == 3)
            {
                var rebel = new Rebel(inputInfo[0], int.Parse(inputInfo[1]), inputInfo[2]);
                townPopulation.Add(rebel);
            }
            else
            {
                var citizen = new Citizen(inputInfo[0], int.Parse(inputInfo[1]), inputInfo[2], inputInfo[3]);
                townPopulation.Add(citizen);
            }
        }

        return townPopulation;
    }
}

