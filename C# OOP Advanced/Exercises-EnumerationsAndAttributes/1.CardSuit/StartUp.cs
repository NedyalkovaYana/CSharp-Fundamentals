using System;

public class StartUp
{
    public static void Main()
    {
        var cardSuit = Suit.Clubs;

        var values = Enum.GetValues(typeof(Suit));

        Console.WriteLine("Card Suits:");
        foreach (var suit in values)
        {
            Console.WriteLine($"Ordinal value: {(int)suit}; Name value: {suit}");
        }
    }
}

