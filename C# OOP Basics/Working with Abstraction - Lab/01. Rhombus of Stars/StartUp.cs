using System;

public class StartUp
{
    public static void Main()
    {
        var size = int.Parse(Console.ReadLine());
        var romb = new Romb(size);
        Console.WriteLine(romb.DrawRomb().ToString());

    }
}

