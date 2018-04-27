using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Stack<T> : IEnumerable<T>
{
    private List<T> data;

    public Stack(params T[] elements)
    {
        this.data = new List<T>(elements);
    }

    public void Pop()
    {
        if (data.Count == 0)
        {
            throw new ArgumentException("No elements");
        }
        data.Remove(data.Last());
    }

    public void Push(params T[] element)
    {
        data.AddRange(element);
    }
    public IEnumerator<T> GetEnumerator()
    {
        data.AddRange(data);
        this.data.Reverse();
        return this.data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    
}

