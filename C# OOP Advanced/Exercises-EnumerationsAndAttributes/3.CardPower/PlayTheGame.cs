using System;
using System.Collections.Generic;

public  class PlayTheGame
{
    private string winner = String.Empty;
    private Card winningCard;

    public void PlayThisGame()
    {
        var firstPlayer = new Player(Console.ReadLine());
        var secondPlayer = new Player(Console.ReadLine());

        while (firstPlayer.cards.Count < 5)
        {
            AddCard(firstPlayer);
        }

        while (secondPlayer.cards.Count < 5)
        {
            AddCard(secondPlayer);
        }

        Console.WriteLine($"{this.winner} wins with {winningCard.currentRank} of {winningCard.currentSuit}.");
    }

    private void AddCard(Player firstPlayer)
    {
        var cardToAdd = Console.ReadLine();
        try
        {
            Card card = firstPlayer.AddCardToCards(cardToAdd);
            this.MaxCardChecker(card, firstPlayer);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void MaxCardChecker(Card card, Player player)
    {
        if (this.winningCard == null)
        {
            winningCard = card;
            winner = player.Name;
        }

        if (card.CompareTo(this.winningCard) > 0)
        {
            this.winningCard = card;
            winner = player.Name;
        }
    }
}

