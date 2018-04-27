using System;
using System.Collections.Generic;

public class StartUp
{
   public static void Main()
   {
       var sortedSetPerson = new SortedSet<Person>();
        var hashSetPerson = new HashSet<Person>(new PersonComparer());

       var n = int.Parse(Console.ReadLine());

       for (int i = 0; i < n; i++)
       {
           var input = Console.ReadLine().Split();
           var name = input[0];
           var age = int.Parse(input[1]);

           sortedSetPerson.Add(new Person(name, age));
           hashSetPerson.Add(new Person(name, age));
       }

       Console.WriteLine(sortedSetPerson.Count);
       Console.WriteLine(hashSetPerson.Count);
   }
}

