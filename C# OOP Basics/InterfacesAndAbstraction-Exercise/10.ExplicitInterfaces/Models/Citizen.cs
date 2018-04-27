using System;

public class Citizen : IPerson, IResident
{
    public string Name { get; }
    public int Age { get; }
    public string Country { get; }

    public Citizen(string name, int age, string country)
    {
        Name = name;
        Age = age;
        Country = country;
    }

    void IResident.GetName()
    {
        Console.WriteLine($"Mr/Ms/Mrs {this.Name}");
    }
    void IPerson.GetName()
    {
        Console.WriteLine($"{this.Name}");
    }
}

