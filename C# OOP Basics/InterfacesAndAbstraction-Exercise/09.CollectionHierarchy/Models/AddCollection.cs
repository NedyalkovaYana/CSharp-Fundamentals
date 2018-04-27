using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class AddCollection<T> : IAddCollection<T>
{
    public AddCollection()
    {
        this.Data = new Stack<T>();
    }
    protected Stack<T> Data { get; set; }
    public virtual int Add(T element)
    {
        this.Data.Push(element);
        return this.Data.Count - 1;
    }
}

