using System;
using System.ComponentModel;

public class Box<T> :  IComparable<Box<T>>
    where T : IComparable  
{
    public T Value { get; set; }
    public Box()
    {
        this.Value = default(T);
    }

    public Box(T value)
    {
        this.Value = value;
    }
    public override string ToString()
    {
        return $"{typeof(T).FullName}: {this.Value}";
    }

    public int CompareTo(Box<T> other)
    {        
        return this.Value.CompareTo(other.Value);
    }
}

