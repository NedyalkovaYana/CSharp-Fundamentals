using System;
using System.Collections.Generic;

public class Engine 
{
    private List<Citizen> citizens;

    public Engine()
    {
        this.citizens = new List<Citizen>();
    }

    public void Run()
    {
        var input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            var data = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var name = data[0];
            var country = data[1];
            var age = int.Parse(data[2]);
            var citizen = new Citizen(name, age, country);
            citizens.Add(citizen);

           ((IPerson)citizen).GetName();
            ((IResident)citizen).GetName();
        }
    }
}

