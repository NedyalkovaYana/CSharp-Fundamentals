using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    
    private NationsBuilder builder;
    public Engine()
    {
        this.builder = new NationsBuilder();
    }

    public void Run()
    {
        var input = string.Empty;
        while ((input = Console.ReadLine()) != "Quit")
        {
            var data = input.Split();
            var command = data[0];
            switch (command)
            {
                case "Bender":
                    this.builder.AssignBender(data.ToList());
                    break;
                case "Monument":
                    this.builder.AssignMonument(data.ToList());
                    break;
                case "Status":
                    Console.WriteLine(this.builder.GetStatus(data[1]).Trim());
                    break;
                case "War":
                    this.builder.IssueWar(data[1]);
                    break;
            }
        }

        Console.WriteLine(builder.GetWarsRecord());
    }

}

