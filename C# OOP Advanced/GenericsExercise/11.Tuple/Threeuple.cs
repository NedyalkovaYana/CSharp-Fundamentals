using System.Runtime.CompilerServices;
public class Tuple<T, U> 
{
    public Tuple(T first, U second)
    {
        this.FirstValue = first;
        this.SecondValue = second;
        
    }

    public string Print()
    {
        return $"{this.FirstValue} -> {this.SecondValue}";
    }

    public T FirstValue { get; set; }
    public U SecondValue { get; set; }
   
}

