 using System;
 using System.Collections.Generic;
 using System.Linq;

public class Player
{
    public string Name { get; set; }
    public List<Card> cards { get; }

    public Player(string name)
    {
        Name = name;
        this.cards = new List<Card>();
    }

    public Card AddCardToCards(string card)
    {
        var findedCard = card.Split();
        var rank = findedCard[0];
        var suit = findedCard[2];

        var checkInRank = Enum.IsDefined(typeof(Card.Rank), rank);
        var checkInSuit = Enum.IsDefined(typeof(Card.Suit), suit);

        if (checkInRank && checkInSuit)
        {
            var cardToAdd  = new Card(rank, suit);

            if (cards.Count > 0)
            {
                if (this.cards.Any(c => c.CompareTo(cardToAdd) == 0))
                {
                    throw new ArgumentException("Card is not in the deck.");
                }
            }
           
            cards.Add(cardToAdd);
            return cardToAdd;
        }
        else
        {
            throw new ArgumentException("No such card exists");
        }
    }
}

