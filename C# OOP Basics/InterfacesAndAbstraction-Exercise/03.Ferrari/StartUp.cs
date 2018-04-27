using System;

public class StartUp
{
    public static void Main()
    {
        string ferrariName = typeof(Ferrari).Name;
        string iCarInterfaceName = typeof(ICar).Name;

        bool isCreated = typeof(ICar).IsInterface;
        if (!isCreated)
        {
            throw new Exception("No interface ICar was created");
        }

        var name = Console.ReadLine();
        var ferrari = new Ferrari(name);
        Console.WriteLine(ferrari.ToString());
    }
}

