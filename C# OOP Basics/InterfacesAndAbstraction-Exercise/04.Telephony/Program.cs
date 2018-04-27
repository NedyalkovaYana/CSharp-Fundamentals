using System;

public  class Program
{
    public static void Main()
    {
        var phoneNumbers = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
        var phone = new Smartphone("Smartphone");

        foreach (var numbers in phoneNumbers)
        {
            Console.WriteLine(phone.Call(numbers));
        }

        var sites = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (sites.Length == 0)
        {
            Console.WriteLine("Browsing: !");
        }

        foreach (var site in sites)
        {
            Console.WriteLine(phone.Browse(site));
        }
    }
}

