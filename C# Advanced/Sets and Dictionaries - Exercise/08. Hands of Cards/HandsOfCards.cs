namespace _08.Hands_of_Cards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

    class HandsOfCards
    {
        static void Main()
        {
            var cardsDict = new Dictionary<string, HashSet<string>>();

            var uniqueCards = new HashSet<string>();
            var inputData = string.Empty;

            while ((inputData = Console.ReadLine()) != "JOKER")
            {
                var tokens = inputData
                    .Split(new String[] {": "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var person = tokens[0];
                var cards = tokens[1]
                    .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                for (int i = 0; i < cards.Count; i++)
                {
                    uniqueCards.Add(cards[i]);
                }

                if (!cardsDict.ContainsKey(person))
                {
                    cardsDict.Add(person, new HashSet<string>());
                }
                cardsDict[person].UnionWith(uniqueCards);
                uniqueCards.Clear();
            }

            foreach (var person in cardsDict)
            {
                var score = GetScoreOfCards(person.Value);
                Console.WriteLine($"{person.Key}: {score}");
            }

        }


        static int GetScoreOfCards(HashSet<string> personValue)
        {
            var multupliedCards = 0;
            var score = 0;
            var cardsToList = personValue.ToList();

            for (int i = 0; i < cardsToList.Count; i++)
            {
                var power = 0;
                var type = 0;
                var currentCardPower = new String(cardsToList[i].ToCharArray().Where(c => Char.IsDigit(c)).ToArray());

                if (currentCardPower == String.Empty)
                {
                    currentCardPower = cardsToList[i].ToCharArray()[0].ToString();
                    switch (currentCardPower)
                    {
                        case "J":
                            power = 11;
                            break;
                        case "Q":
                            power = 12;
                            break;
                        case "K":
                            power = 13;
                            break;
                        case "A":
                            power = 14;
                            break;
                    }
                }
                else
                {
                    power = int.Parse(currentCardPower);
                }

                var typeCard = cardsToList[i].ToCharArray().Last().ToString();
                switch (typeCard)
                {
                    case "S":
                        type = 4;
                        break;
                    case "H":
                        type = 3;
                        break;
                    case "D":
                        type = 2;
                        break;
                    case "C":
                        type = 1;
                        break;
                }

                multupliedCards = power * type;
                score += multupliedCards;
            }

            return score;
        }
    }
}
