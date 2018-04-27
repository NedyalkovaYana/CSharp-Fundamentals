using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public class Program
{
    public static void Main()
    {
        //Problem5();

        //Problem6();

        //Problem7();

        var playTheGame = new PlayTheGame();
        playTheGame.PlayThisGame();
    }

    private static void Problem7()
    {
        Console.ReadLine();

        var ranks = Enum.GetNames(typeof(Card.Rank));

        PrintCardsBySuit(ranks, Card.Suit.Clubs);
        PrintCardsBySuit(ranks, Card.Suit.Hearts);
        PrintCardsBySuit(ranks, Card.Suit.Diamonds);
        PrintCardsBySuit(ranks, Card.Suit.Spades);
    }

    public static void PrintCardsBySuit(string[] ranks, Card.Suit suit)
    {
        Console.WriteLine($"{Card.Rank.Ace} of {suit}");
        Console.WriteLine(string.Join(Environment.NewLine, ranks.Take(ranks.Length - 1)
            .Select(r => $"{r} of {suit}")));
    }
    private static void Problem6()
    {
        var targetENum = Console.ReadLine();

        var enumType = targetENum == "Rank"
            ? typeof(Card.Rank)
            : typeof(Card.Suit);

        var attributeData = enumType.GetCustomAttributes(false);

        Console.WriteLine(string.Join(Environment.NewLine, attributeData));
    }

    private static void Problem5()
    {
        var cards = new List<Card>();

        for (int i = 0; i < 2; i++)
        {
            var cardRank = Console.ReadLine();
            var cardSuit = Console.ReadLine();

            var card = new Card(cardRank, cardSuit);
            cards.Add(card);
        }

        Card powerfulCard = null;
        Card tempPowerfulCard;

        var currentPower = 0;
        var maxPower = 0;

        for (int i = 0; i < cards.Count - 1; i += 2)
        {
            currentPower = cards[i].CompareTo(cards[i + 1]);
            tempPowerfulCard = cards.First(c => (int)c.currentSuit + (int)c.currentRank == currentPower);

            if (currentPower > maxPower)
            {
                maxPower = currentPower;
                powerfulCard = tempPowerfulCard;
            }
        }

        Console.WriteLine(powerfulCard.ToString());
    }
}

