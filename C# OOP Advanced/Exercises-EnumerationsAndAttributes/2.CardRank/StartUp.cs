
using System;

public class StartUp
{
    static void Main()
    {
        var values = Enum.GetValues(typeof(CardRank));

        Console.WriteLine("Card Ranks:");
        foreach (var value in values)
        {
            Console.WriteLine($"Ordinal value: {(int)value}; Name value: {value}");
        }
    }
}

