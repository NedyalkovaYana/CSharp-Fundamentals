using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var sortedSetByAge = new SortedSet<Person>(new ComparerAge());
        var sortedSetByNameLength = new SortedSet<Person>(new ComparerName());

        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            var name = input[0];
            var age = int.Parse(input[1]);
            sortedSetByAge.Add(new Person(name, age));
            sortedSetByNameLength.Add(new Person(name, age));
        }

        foreach (var peson in sortedSetByNameLength)
        {
            Console.WriteLine($"{peson.Name} {peson.Age}");
        }

        foreach (var person in sortedSetByAge)
        {
            Console.WriteLine($"{person.Name} {person.Age}");
        }
    }
}

