using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {

        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MemberInfo addMemberInfo = typeof(Family).GetMethod("AddMember");

        if (oldestMemberMethod == null || addMemberInfo == null)
        {
            throw new Exception();
        }

        var family = new Family();
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var personData = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);

            var result = family.People.Select(a => a.Name == personData[0]);
            if (result.Equals(personData[0]))
            {
                continue;
            }
            var member = new Person(personData[0], int.Parse(personData[1]));
            
            family.AddMember(member);
        }
        var oldestMember = family.GetOldestMember();
        if (oldestMember != null)
        {
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
       
    }
}

