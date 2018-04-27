using System;
using System.Collections.Generic;
using System.Linq;

public class Sorter<T> : List<T>, IComparable
    where T : class
{

    public  List<T> Sort(List<T> collection)
    {
        return collection.OrderBy(a => a).ToList();
    }

    public int CompareTo(object obj)
    {
        return 0;
    }
}

