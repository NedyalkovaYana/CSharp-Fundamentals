using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var peopleList = new List<Person>();

        var numberOfPeople = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfPeople; i++)
        {
            var newPerson = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var name = newPerson[0];
            var age = int.Parse(newPerson[1]);
            var member = new Person(name, age);
            if (!peopleList.Contains(member))
            {
                peopleList.Add(member);
            }

        }
        foreach (var people in peopleList.OrderBy(a => a.Name))
        {
            if (people.Age > 30)
            {
                Console.WriteLine($"{people.Name} - {people.Age}");
            }
           
        }
    }
}

