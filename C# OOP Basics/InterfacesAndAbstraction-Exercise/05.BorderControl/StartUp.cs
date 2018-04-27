using System;
using System.Collections;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<string> townPopulation = AddCitizens();

        PrintDetainedCitizens(townPopulation);
    }

    private static List<string> AddCitizens()
    {
        List<string> townPopulation = new List<string>();
        var citizens = new List<Citizen>();
        var robots = new List<Robot>();
        var inputData = string.Empty;

        while ((inputData = Console.ReadLine()) != "End")
        {
            var tokens = inputData.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 3)
            {
                var personName = tokens[0];
                var age = int.Parse(tokens[1]);
                var personId = tokens[2];
                var person = new Citizen(personId, personName, age);
                citizens.Add(person);
                townPopulation.Add(person.Id);
            }
            else
            {
                var model = tokens[0];
                var robotId = tokens[1];
                var robot = new Robot(robotId, model);
                robots.Add(robot);
                townPopulation.Add(robot.Id);
            }
        }

        return townPopulation;
    }

    private static void PrintDetainedCitizens(List<string> townPopulation)
    {
        var end = Console.ReadLine();
        List<string> detained = new List<string>();
        foreach (var p in townPopulation)
        {
            if (p.EndsWith(end))
            {
                detained.Add(p);
            }
        }
        foreach (var d in detained)
        {
            Console.WriteLine(d);
        }
    }
}

