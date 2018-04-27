using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Data<T> : IComparable<T>
    where T : IComparable<T>
{
    public List<T> dates;

    public Data()
    {
        this.dates = new List<T>();
    }
    public void Add(T element)
    {
        dates.Add(element);
    }

    public T Remove(int index)
    {
        var rem = dates[index];
        dates.Remove(rem);
        return rem;
    }

    public bool Contains(T element)
    {
        if (dates.Contains(element))
        {
            return true;
        }
        return false;
    }

    public void Swap(int index, int index1)
    {
        var temp = this.dates[index];
        this.dates[index] = this.dates[index1];
        this.dates[index1] = temp;
    }

    public int CountGreaterThan(T element)
    {
        var count = 0;
        foreach (var date in dates)
        {
            if (date.CompareTo(element) > 0)
            {
                count++;
            }
        }

        return count;
    }

    public T Max()
    {
        return dates.Max();
    }

    public T Min()
    {
        return dates.Min();
    }

    public int CompareTo(T other)
    {
        var count = 0;
        return count;
    }

    public string Print()
    {
        var sb = new StringBuilder();

        foreach (var data in dates)
        {
            sb.AppendLine(data.ToString());
        }

        return sb.ToString().Trim();
    }

}

