using System.Collections.Generic;
public class ComparerName : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        var comparison = x.Name.Length.CompareTo(y.Name.Length);

        return comparison == 0 ? 
            (int) (char.ToLower(x.Name[0]))
            .CompareTo(char.ToLower(y.Name[0])) : comparison;
    }
}

