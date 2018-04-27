using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        Box<int> box = new Box<int>();
        box.Add(1);
        box.Add(2);
        box.Add(3);
        Console.WriteLine(box.Remove());
        box.Add(4);
        box.Add(5);
        Console.WriteLine(box.Remove());

       
    }
}

