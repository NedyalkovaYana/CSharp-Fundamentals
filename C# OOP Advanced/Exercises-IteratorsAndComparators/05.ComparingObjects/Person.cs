using System;
using System.Runtime.Remoting;

public class Person : IComparable<Person>
{
    public Person(string name, int age, string town)
    {
        this.Name = name;
        this.Age = age;
        this.Town = town;
    }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Town { get; set; }

    public int CompareTo(Person other)
    {
        var compareResult = this.Name.CompareTo(other.Name);
        if (compareResult != 0)
        {
            return compareResult;
        }

        compareResult = this.Age.CompareTo(other.Age);
        if (compareResult != 0)
        {
            return compareResult;
        }

        return this.Town.CompareTo(other.Town);
    }
}

