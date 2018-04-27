using System;

public  class Card : IComparable<Card>, IEquatable<Card>
{
    private int power;
    public Card(string rank, string suit)
    {
        this.currentRank = (Rank)Enum.Parse(typeof(Rank), rank);
        this.currentSuit = (Suit)Enum.Parse(typeof(Suit), suit);
        this.power = (int) this.currentRank + (int) currentSuit;
    }

    public Suit currentSuit { get; set; }
    public Rank currentRank { get; set; }

    [Type("Enumeration", "Rank", "Provides rank constants for a Card class.")]
    public enum Rank
    {
        Ace = 14,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }

    [Type("Enumeration", "Suit", "Provides suit constants for a Card class.")]
    public enum Suit
    {
        Clubs = 0,
        Hearts = 26,
        Diamonds = 13,
        Spades = 39
    }   
    public override string ToString()
    {
        return 
            $"Card name: {currentRank} of {currentSuit}; " +
            $"Card power: {(int)currentRank + (int)currentSuit}";
    }

    public int CompareTo(Card other)
    {
        return this.power - other.power;
    }

    public bool Equals(Card other)
    {
        var checkRanl = this.currentRank.CompareTo(other.currentRank);
        var checkSuit = this.currentSuit.CompareTo(other.currentSuit);
        return currentSuit == other.currentSuit && currentRank == other.currentRank;
    }
}

