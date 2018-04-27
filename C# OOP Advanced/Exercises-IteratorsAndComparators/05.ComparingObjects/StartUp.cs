using System;
using System.Collections.Generic;

public  class StartUp
{
    public static void Main()
    {
        var people = new List<Person>();

        var inputPeople = string.Empty;
        while ((inputPeople = Console.ReadLine()) != "END")
        {
            var tokens = inputPeople.Split();
            var name = tokens[0];
            var age = int.Parse(tokens[1]);
            var town = tokens[2];

            people.Add(new Person(name, age, town));
        }

        var indexOfPerson = int.Parse(Console.ReadLine()) - 1;

        var person = people[indexOfPerson];
        var equalsPeope = 0;
        var notEqualsPeope = 0;
        foreach (var peope in people)
        {
            var result = peope.CompareTo(person);
            if (result != 0)
            {
                notEqualsPeope++;
            }
            else
            {
                equalsPeope++;
            }
        }
        if (equalsPeope <= 0 || equalsPeope == 1)
            Console.WriteLine("No matches");

        else
           Console.WriteLine($"{equalsPeope} {notEqualsPeope} {people.Count}");
    }
}

