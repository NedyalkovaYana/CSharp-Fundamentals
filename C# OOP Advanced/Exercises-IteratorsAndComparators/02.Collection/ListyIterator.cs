using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{
    private readonly List<T> data;
    private int currentIndex;
    public ListyIterator(params T[] parameters)
    {
        this.data = new List<T>(parameters);
        this.currentIndex = 0;
    }

    public bool Move()
    {
        if (this.currentIndex < this.data.Count - 1)
        {
            currentIndex++;
            return true;
        }

        return false;
    }

    public bool NextIndex() => this.currentIndex < data.Count - 1;

    public T Print()
    {
        if (data.Count == 0)
        {
            throw new ArgumentException("Invalid Operation!");
        }

        return data[currentIndex];
    }

    public IEnumerator<T> GetEnumerator()
    {
        return data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

}

