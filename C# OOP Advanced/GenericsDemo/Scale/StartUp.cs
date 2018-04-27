using System;

public class StartUp
{
    public static void Main()
    {
        Scale<int> ints = new Scale<int>(3, 3);
        Console.WriteLine(ints.GetHeavier());
    }
}